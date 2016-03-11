#pragma once
#include <list>
#include "Goal.h"

using namespace std;



template <class entity_type>
class Goal_Composite : public Goal<entity_type>
{
private:
	typedef list<Goal<entity_type>*> SubgoalList;

public:
	Goal_Composite(entity_type* agent, Goal_Type type) :
		Goal<entity_type>(agent, type)
	{}

	virtual ~Goal_Composite() { removeAllSubgoals(); }

	virtual void activate() = 0;

	virtual int process() = 0;

	virtual void terminate() = 0;

	bool handleMessage(const Telegram& msg)
	{
		return forwardMessageToFronMostSubgoal(msg);
	}

	virtual void addSubgoal(Goal<entity_type>* goal);

	void removeAllSubgoals();

protected:
	int processSubgoals();

	bool forwardMessageToFronMostSubgoal(const Telegram& msg);

	SubgoalList m_Subgoals;

};

template <class entity_type>
int Goal_Composite<entity_type>::processSubgoals()
{
	while (!m_Subgoals.empty() &&
			(m_Subgoals.front()->isComplete() || 
			m_Subgoals.front()->hasFailed()))
	{
		m_Subgoals.front()->terminate();
		delete m_Subgoals.front();
		m_Subgoals.pop_front();
	}

	if (!m_Subgoals.empty())
	{
		int statusSubgoals = m_Subgoals.front()->process();
		if (completed == statusSubgoals && m_Subgoals.size() > 1)
		{
			return active;
		}

		return statusSubgoals;
	}
	else
	{
		return completed;
	}
}

template <class entity_type>
bool Goal_Composite<entity_type>::forwardMessageToFronMostSubgoal(const Telegram& msg)
{
	if (!m_Subgoals.empty())
	{
		return m_Subgoals.front()->handleMessage(msg);
	}

	return false;
}

template <class entity_type>
void Goal_Composite<entity_type>::removeAllSubgoals()
{
	for (SubgoalList::iterator it = m_Subgoals.begin();
		 it != m_Subgoals.end();
		 ++it)
	{
		(*it)->terminate();
		delete *it;
	}

	m_Subgoals.clear();
}

template <class entity_type>
void Goal_Composite<entity_type>::addSubgoal(Goal<entity_type>* goal)
{
	m_Subgoals.push_front(goal);
}