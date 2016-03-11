#pragma once

class Goal_Think;



class Agent
{
public:
	Agent(int id);
	virtual ~Agent() {}

	void setBrain(Goal_Think* brain) { Brain = brain; }

	Goal_Think* const getBrain() const
	{
		return Brain;
	}

	int getCurHealthPoint() const { return CurHealthPoint; }
	void setCurHealthPoint(int val) { CurHealthPoint = val; }
	int getMaxHealthPoint() const { return MaxHealthPoint; }
	void setMaxHealthPoint(int val) { MaxHealthPoint = val; }
	int getMoney() const { return Money; }
	void setMoney(int val) { Money = val; }
	int getMoneyNextNeeded() const { return MoneyNextNeeded; }
	void setMoneyNextNeeded(int val) { MoneyNextNeeded = val; }
	int getTime() const { return Time; }
	void setTime(int val) { Time = val; }
	int getEnergy() const { return Energy; }
	void setEnergy(int val) { Energy = val; }

	void setTotalCodeLine(int val) { TotalCodeLine = val; }
	int getTotalCodeLine() { return TotalCodeLine; }
	void setTotalArtResSize(int val) { TotalArtistResSize = val; }
	int getTotalArtResSize() const { return TotalArtistResSize; }

	void setCurCodeLine(int val) { CurCodeLine = val; }
	int getCurCodeLine() const { return CurCodeLine; }

	void setCurArtistResSize(int val) { CurArtistResSize = val; }
	int getCurArtistResSize() const { return CurArtistResSize; }

	void addFinishedCodeLine(int val) { CurCodeLine += val; }
	void addFinishedArtistRes(int val) { CurArtistResSize += val; }

	bool isCodeAllFinished() { return CurCodeLine >= TotalCodeLine; }
	bool isArtistResWorkOk() { return  CurArtistResSize >= TotalArtistResSize; }

public:
	void tapCodes(int num);
	void produceArtRes(int num);

protected:
	int ID;

	Goal_Think* Brain;

	int CurHealthPoint;
	int MaxHealthPoint;
	int Money;
	int MoneyNextNeeded;
	int Time;
	int Energy;

	int TotalCodeLine;
	int TotalArtistResSize;

	int CurCodeLine;
	int CurArtistResSize;

};