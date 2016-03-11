#pragma once

#include "Agent.h"



class Goal_Evaluator
{
protected:
	double m_dCharacterBias;

public:
	Goal_Evaluator(double characterBias) : m_dCharacterBias(characterBias) {}

	virtual double calculateDesirability(Agent* agent) { return 0; }

	virtual void setGoal(Agent* agent) {}

};