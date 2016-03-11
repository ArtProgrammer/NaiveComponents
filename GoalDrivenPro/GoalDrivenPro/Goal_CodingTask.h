#pragma once
#include "Goal.h"
#include "ProgrammerGoalTypes.h"
#include "Agent.h"



class Goal_CodingTask : public Goal<Agent>
{
private:
	int Line;

public:
	Goal_CodingTask(Agent* agent);
	void activate();
	int process();
	void terminate();
	
	void setLine(int val) { Line = val; }
	int getLine() const { return Line; }
};
