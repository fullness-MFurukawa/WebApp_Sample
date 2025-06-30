Feature: 部署オブジェクトの生成
    部署のIDと名称を使ってDepartmentオブジェクトを生成する

    Scenario: 正常なIDと部署名でDepartmentオブジェクトを生成できる
    Given 部署IDが1である
    When 部署名が"総務部"である
    Then Departmentオブジェクトが生成される

