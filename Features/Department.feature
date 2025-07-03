Feature: 部署オブジェクトの生成
  Scenario: 正常なIDと部署名でDepartmentオブジェクトを生成できる
    Given 部署IDと部署名を用意する "1" "総務部"
    When 部署オブジェクトを生成する
    Then 生成されたオブジェクトのIDと名称を検証する "1" "総務部" 