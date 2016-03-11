#pragma once
#include "Goal_Evaluator.h"
#include "Goal_Think.h"



class DevGameGoal_Evaluator : public Goal_Evaluator
{
public:
	DevGameGoal_Evaluator(double factor) :
		Goal_Evaluator(factor)
	{}

	double calculateDesirability(Agent* agent)
	{
		return 1.0f;
	}

	void setGoal(Agent* agent)
	{
		agent->getBrain()->addGameDevGoal();
	}

};
