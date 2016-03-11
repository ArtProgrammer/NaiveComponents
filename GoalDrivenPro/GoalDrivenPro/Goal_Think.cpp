#include "Goal_Think.h"
#include "Goal_DevGame.h"
#include "Goal_CodingTask.h"
#include "DevGameGoal_Evaluator.h"



Goal_Think::Goal_Think(Agent* agent) :
	Goal_Composite<Agent>(agent, goal_think)
{
	/*m_Evaluators.push_back(new BuildHealthGoal_Evaluator(1.0));
	m_Evaluators.push_back(new EarnMoneyGoal_Evaluator(1.0));*/

	m_Evaluators.push_back(new DevGameGoal_Evaluator(1.0));
}

Goal_Think::~Goal_Think()
{
	GoalEvaluators::iterator it = m_Evaluators.begin();
	for (; it != m_Evaluators.end(); ++it)
	{
		if (*it)
		{
			delete *it;
		}
	}

	m_Evaluators.clear();
}

void Goal_Think::activate()
{
	if (true)
	{
		arbitrate();
	}

	m_Status = active;
}

int Goal_Think::process()
{
	activateIfInactive();

	int substatus = processSubgoals();

	if (completed == substatus ||
		failed == substatus)
	{
		if (true)
		{
			m_Status = inactive;
		}
	}

	return m_Status;
}

void Goal_Think::terminate()
{

}

void Goal_Think::arbitrate()
{
	double best = 0.0;
	Goal_Evaluator* mostDesirable = nullptr;

	GoalEvaluators::iterator curDes = m_Evaluators.begin();
	for (curDes; curDes != m_Evaluators.end(); ++curDes)
	{
		double desirability = (*curDes)->calculateDesirability(m_Owner);

		if (desirability >= best)
		{
			best = desirability;
			mostDesirable = *curDes;
		}
	}

	if (mostDesirable) mostDesirable->setGoal(m_Owner);
}

bool Goal_Think::handleMessage()
{
	return true;
}

void Goal_Think::addGameDevGoal()
{
	addSubgoal(new Goal_DevGame(m_Owner));
}

void Goal_Think::addCodingTask()
{
	addSubgoal(new Goal_CodingTask(m_Owner));
}
