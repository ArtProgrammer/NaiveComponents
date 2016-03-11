#pragma once

#include <vector>
#include "Goal_Composite.h"
#include "Goal_Evaluator.h"

#include "BuildHealthGoal_Evaluator.h"
#include "EarnMoneyGoal_Evaluator.h"



using namespace std;



class Goal_Think : public Goal_Composite<Agent>
{
public:
	typedef vector<Goal_Evaluator*> GoalEvaluators;

public:
	Goal_Think(Agent* agent);
	virtual ~Goal_Think();

	void activate();
	int process();
	void terminate();

	void arbitrate();
	bool handleMessage();

public:
	void addGameDevGoal();
	void addCodingTask();

protected:
	GoalEvaluators m_Evaluators;

};


