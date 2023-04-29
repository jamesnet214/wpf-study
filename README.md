# WPF Study

WPF 스터디 시즌 3 문서입니다.

## Content

- [x] 1. Button
- [ ] 2. ControlTemplate
- [ ] 3. DataTemplate
- [ ] 4. Trigger
- [ ] 5. ContentControl
- [ ] 6. ListBox
- [ ] 7. ListBoxItem
- [ ] 8. ItemsControl
- [ ] 9. CustomControl
- [ ] 10. GetContainerItemForOverride
- [ ] 11. AutoGrid.Core
- [ ] 12. CommunityToolkit
- [ ] 13. NugetPackage

## 1. Button
- Content -> 내용

## 2. ControlTemplate

- Template -> ControlTemplate
- ControlTemplate -> TargetType

## 3. DataTemplate

TBD...

## 4. Trigger

TBD...

## 5. ContentControl

- ```Content``` 프로퍼티를 갖고 있다.
- ```Content``` 타입은 ```object``` 로 다른 Control 을 넣을 수 있다.
```xml
<!-- case 1. text content-->
<Button Content="버튼"/>

<!-- case 2. control content -->
<Button>
    <Button.Content>
        <StackPanel Orientation="Horizontal">
            <CheckBox/>
            <TextBlock Text="버튼"/>
        </StackPanel>
    </Button.Content>
</Button>
```
- ```Content``` 로 문자열만 입력된 경우는 내부적으로 ```TextBlock```이 추가됐다고 볼 수 있다.
```xml
<!-- case 1 -->
<Button Content="버튼"/>

<!-- case 2 -->
<Button>
    <Button.Content>
        버튼
    </Button.Content>
</Button>

<!-- case 3 -->
<Button>
    <Button.Content>
        <TextBlock Text="버튼"/>
    </Button.Content>
</Button>
```
- ```ContentTemplate``` 프로퍼티를 갖고 있다.
- ```ContentTemplate``` 타입은 ```DateTemplate``` 으로 Resource에 정의한 DataTemplate을 넣을 수 있다.
```xml
<Window.Resources>
    <!-- DataTemplate example -->
    <DataTemplate x:Key="buttonContentTemplate">
        <TextBlock Text="버튼"/>
    </DataTemplate>
</Window.Resources>

<Grid>
    <!-- Use ContentTemplate -->
    <Button ContentTemplate="{StaticResource buttonContentTemplate}"/>    
</Grid>
```
- Xaml 에서 ```Content``` 태그는 생략 가능하다.
```xml
<Button>
    <Button.Content>
        버튼
    </Button.Content>
</Button>

<!-- Content Tag 생략 -->
<Button>
    버튼
</Button>
```

| 클래스 | 부모 클래스 |
|:------|:------------|
| Button | ButtonBase |
| CheckBox | ContentControl |
| RadioButton | ContentControl |
| ToggleButton | ContentControl |
| ListBoxItem | ContentControl |
| Label | ContentControl |
| ComboBoxItem | ContentControl |
| ListViewItem | ContentControl |
| TreeViewItem | ContentControl |
| GroupBox | ContentControl |
| Window | ContentControl |
| UserControl | ContentControl |
| ScrollViewer | ContentControl |




