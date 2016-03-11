#pragma once

#include "Goal_Evaluator.h"



class EarnMoneyGoal_Evaluator : public Goal_Evaluator
{
public:
	EarnMoneyGoal_Evaluator(double characterBias) :
		Goal_Evaluator(characterBias) {}

	double calculateDesirability(Agent* agent)
	{
		const double tweak = 1.0;

		return tweak - agent->getMoney() * tweak / agent->getMoneyNextNeeded();
	}

	void setGoal(Agent* agent)
	{
		agent->getBrain();
	}

};
