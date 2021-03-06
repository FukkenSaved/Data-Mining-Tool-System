#include "ISolver.h"

namespace dms::solvers
{
	ISolver::ISolver(Int32 inputs, Int32 outputs)
	{
		inputsCount = inputs;
		outputsCount = outputs;
	}

	int ISolver::GetInputsCount()
	{
		return inputsCount;
	}

	int ISolver::GetOutputsCount()
	{
		return outputsCount;
	}

	std::vector<std::string> ISolver::getAttributes()
	{
		return std::vector<std::string>();
	}

	std::vector<LearningOperation> ISolver::getOperations()
	{
		return std::vector<LearningOperation>();
	}

	ISolver::~ISolver()
	{
	}
}