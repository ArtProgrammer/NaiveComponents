#pragma once
#include "Goal_Composite.h"
#include "ProgrammerGoalTypes.h"
#include "Agent.h"



class Goal_DevGame : public Goal_Composite<Agent>
{
public:
	Goal_DevGame(Agent* agent) : 
		Goal_Composite<Agent>(agent, goal_devgame)
	{}

	void activate();
	int process();
	void terminate() { m_Status = completed; }
	bool handleMessage(const Telegram& msg);

};
