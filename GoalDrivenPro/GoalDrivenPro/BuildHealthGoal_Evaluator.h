#pragma once

#include "Goal_Evaluator.h"


class BuildHealthGoal_Evaluator : public Goal_Evaluator
{
public:
	BuildHealthGoal_Evaluator(double characterBias) : 
		Goal_Evaluator(characterBias)
	{

	}

	double calculateDesirability(Agent* agent)
	{
		const double tweak = 0.5f;

		return tweak - agent->getCurHealthPoint() * tweak / agent->getMaxHealthPoint();
	}

	void setGoal(Agent* agent)
	{

	}
};
