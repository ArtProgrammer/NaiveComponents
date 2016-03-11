#pragma once
#include "Goal.h"
#include "ProgrammerGoalTypes.h"
#include "Agent.h"



class Goal_ArtistResTask : public Goal<Agent>
{
public:
	Goal_ArtistResTask(Agent* agent);
	void activate();
	int process();
	void terminate();

};
