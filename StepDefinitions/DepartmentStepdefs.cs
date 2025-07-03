using System;
using Reqnroll;
using WebApp_Sample.Applications.Domains;
using ZstdSharp.Unsafe;

namespace MyNamespace;

[Binding]
public class StepDefinitions
{

	private int _id;
	private string _name;
	private Department _department;

	[Given(@"部署IDと部署名を用意する ""(.*)"" ""(.*)""")]
	public void 部署IDと部署名を用意する(string id, string name)
	{
		_id = int.Parse(id);
		_name = name;
	}

	[When(@"部署オブジェクトを生成する")]
	public void 部署オブジェクトを生成する()
	{
		_department = new Department(_id, _name);
	}

	[Then(@"生成されたオブジェクトのIDと名称を検証する ""(.*)"" ""(.*)""")]
	public void 生成されたオブジェクトのIDと名称を検証する(string id,string name)
	{
		
	}
}
