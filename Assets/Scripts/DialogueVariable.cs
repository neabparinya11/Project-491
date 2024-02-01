using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using System.IO;

public class DialogueVariable
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    public DialogueVariable(string filePath)
    {
        string inkContents = File.ReadAllText(filePath);
        Ink.Compiler compiler = new Ink.Compiler(inkContents);
        Story storyVariables = compiler.Compile();

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in storyVariables.variablesState)
        {
            Ink.Runtime.Object value = storyVariables.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Initial ink variable");
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if (variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
