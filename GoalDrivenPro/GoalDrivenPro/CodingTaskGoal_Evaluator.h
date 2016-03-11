#pragma once
#include "Goal_Evaluator.h"
#include "Goal_Think.h"



class CodingTaskGoal_Evaluator : public Goal_Evaluator
{
public:
	CodingTaskGoal_Evaluator(double factor) :
		Goal_Evaluator(factor)
	{}

	double calculateDesirability(Agent* agent)
	{
		return 1.0f;
	}

	void setGoal(Agent* agent)
	{
		agent->getBrain()->addCodingTask();
	}

};
