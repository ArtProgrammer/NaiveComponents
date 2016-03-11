#pragma once
#include "ProgrammerGoalTypes.h"
#include "Agent.h"
#include "Telegram.h"
#include <vector>



template <class entity_type>
class Goal
{
public:
	enum GoalState
	{
		active,
		inactive,
		completed,
		failed,
	};

public:
	Goal(entity_type* agent, Goal_Type type) :
		m_Owner(agent),
		GoalType(type),
		m_Status(inactive)
	{}

	virtual ~Goal() {}

	void activateIfInactive();

	void reactivateIfFailed();

	virtual void activate() = 0;

	virtual int process() = 0;

	virtual void terminate() = 0;

	virtual bool handleMessage(const Telegram& msg) { return false; }

	virtual void addSubgoal(Goal<entity_type>* g)
	{
		throw std::runtime_error("Cannot add goals to atomic goals");
	}

	bool isAcive() { return active == m_Status; }

	bool isInactive() { return inactive == m_Status; }

	bool isComplete() { return completed == m_Status; }

	bool hasFailed() { return failed == m_Status; }

	Goal_Type getType() { return GoalType; }

protected:
	GoalState m_Status;
	entity_type* m_Owner;
	Goal_Type GoalType;

};



template <class entity_type>
void Goal<entity_type>::activateIfInactive()
{
	if (isInactive())
	{
		activate();
	}
}

template <class entity_type>
void Goal<entity_type>::reactivateIfFailed()
{
	if (hasFailed())
	{
		m_Status = inactive;
	}
}