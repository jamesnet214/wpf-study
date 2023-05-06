# WPF Study

WPF 스터디 시즌 3 문서입니다.

참고 내용
- [Git](https://blog.naver.com/jamesnet214/222991222558)
- [Markdown](https://blog.naver.com/jamesnet214/222983692433)
- GitHub Profile
- GitHub Wiki
- Nuget Dark Theme
- [ListBox Exam](https://blog.naver.com/jamesnet214/222975314777)
- [AutoGrid.Core](https://blog.naver.com/jamesnet214/222982802666)

## Content

- [x] 1. [Button](#1-button)
- [x] 2. [ControlTemplate](#2-controltemplate)
- [x] 3. [DataTemplate](#3-datatemplate)
- [x] 4. [Trigger](#4-trigger)
- [x] 5. [ContentControl](#5-contentcontrol)
------------------------------------------------------
- [ ] 6. ListBox
- [ ] 7. ListBoxItem
- [ ] 8. ItemsControl
- [ ] 9. CustomControl
- [ ] 10. GetContainerItemForOverride
- [ ] 11. AutoGrid.Core
- [ ] 12. CommunityToolkit

- [ ] 13. NugetPackage

## 1. Button

- [ContentControl](#5-contentcontrol)을 상속한다.
- 즉, ```Content``` 프로퍼티를 갖고 있으며 이는 곧 Button의 내용이다.

```xml
<Button Content="버튼"/>
```

## 2. ControlTemplate

- ```Control``` 클래스가 갖고 있는 ```Template``` 프로퍼티의 타입이다.
- ```Control``` 의 ```Template```을 정의(set value)한다는 것은, 해당 ```Control```의 기존 xaml 구성을 모두 지우고 다시 그리겠다는 의미다.
```xml
<Button>
    <Button.Template>
        <!-- ControlTemplate 을 정의하는 순간 본래 Button의 모습을 잃어버린다. -->
        <ControlTemplate>
            <!-- StackPanel, CheckBox, TextBlock 으로 새로운 Button을 그린다. -->
            <StackPanel Orientation="Horizontal">
                <CheckBox/>
                <TextBlock Text="Button"/>
            </StackPanel>
        </ControlTemplate>
    </Button.Template>
</Button>
```
- ```ControlTemplate``` 은 ```TargetType``` 프로퍼티를 갖고 있다.
- ```TargetType``` 으로 새로 그리는 ```Control```의 타입을 알려줘야 해당 ```Control```의 고유 프로퍼티를 호출/연결할 수 있다.
- ```ControlTemplate``` 은 ```Triggers``` 프로퍼티를 갖고 있다. 
- ```Triggers```의 타입은 ```TriggerCollection```으로, ```TriggerBase```를 아이템으로 가진다. ([4. Trigger](#4-trigger) 참조)
- ```Trigger``` 를 등록하여 대상 ```Control```의 상태를 감시하고 변경 할 수 있다. ([4. Trigger](#4-trigger) 참조)

```xml
<!-- TargetType 으로 Button 지정 -->
<ControlTemplate TargetType="{x:Type Button}">
    ...
    <ControlTemplate.Triggers>
        <!-- Button(ButtonBase)의 고유 프로퍼티인 IsPressed 와 연결 가능 -->
        <!-- IsPressed True 로 변경 시 Background 값 #777777 으로 변경 -->
        <Trigger Property="IsPressed" Value="True">
            <Setter Property="Background" Value="#777777"/>
        </Trigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
```


- 대상 ```Control``` 의 프로퍼티와 연결하기 위해 ```TemplateBinding```을 사용한다.

```xml
<ControlTemplate TargetType="{x:Type Button}">
    <!-- Button의 BorderBrush, Background 프로퍼티를 연결 -->
    <Border BorderBrush="{TemplateBinding BorderBrush}"
            Background="{TemplateBinding Background}"
            BorderThickness="1"
            Padding="16 6">
    </Border>
    
    <ControlTemplate.Triggers>
        <Trigger Property="IsPressed" Value="True">
            <Setter Property="Background" Value="#777777"/>
        </Trigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
```


- 내부 Control에 ```Name```을 부여하여 내부에서 직접 접근하는 방법도 있다.

```xml
<ControlTemplate TargetType="{x:Type Button}">
    <!-- 내부 Control에 border Name 부여 -->
    <!-- Background 연결 해제 -->
    <Border x:Name="border"
            BorderBrush="{TemplateBinding BorderBrush}"
            Background="#eeeeee"
            BorderThickness="1"
            Padding="16 6">
    </Border>
    
    <ControlTemplate.Triggers>
        <Trigger Property="IsPressed" Value="True">
            <!-- TargetName 으로 border를 지정하여 Border Background에 직접 접근 -->
            <Setter TargetName="border" Property="Background" Value="#777777"/>
        </Trigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
```

- 대상 ```Control``` 이 ```ContentControl```을 상속하고 있다면, ```ContentPresenter```를 통해 ```ContentTemplate```을 바인딩 할 수 있다.

```xml
<ControlTemplate TargetType="{x:Type Button}">
    <!-- 내부 Control에 border Name 부여 -->
    <!-- Background 연결 해제 -->
    <Border x:Name="border"
            BorderBrush="{TemplateBinding BorderBrush}"
            Background="{TemplateBinding Background}"
            BorderThickness="1"
            Padding="16 6">
        <!-- ContentPresenter 로 Content 바인딩 -->
        <ContentPresenter/>
        <!-- 아래 코드와 같은 의미
        <ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}"/>
        -->
    </Border>
</ControlTemplate>
```


## 3. DataTemplate

- ContentControl을 상속 받는 클래스의 ContentTemplate을 재정의 해줌
  - `Content`를 재정의하고 있으며, `ContentControl`을 상속 받는 `Window`나 `Button`이나 모두 같은 원리로 동작한다.(ContentControl을 상속 받는 모든 개체)
  - `Button`, `ToggleButton`, `CheckBox`, `RadioButton` 등에 모두 같은 `DataTemplate`이 적용된 것을 볼 수 있다.


- 실행 화면 (좌측부터 `Button`, `ToggleButton`, `CheckBox`, `RadioButton` - 같은 `DataTemplate`을 사용하고 있다.)

![DataTemplate Test](https://user-images.githubusercontent.com/72642836/235357755-1ed92831-42a2-4092-918c-9540b061420e.png)

```xml
<!-- 위 화면의 xaml 코드 -->
    <Window.Resources>
        <DataTemplate x:Key="ButtonContentTemplate">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="50"/>
                    <ColumnDefinition Width="70"/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Row="0" Grid.Column="0" Text="Text1"/>
                <TextBlock Grid.Row="1" Grid.Column="1" Text="Text2"/>
            </Grid>
        </DataTemplate>
    </Window.Resources>
    <StackPanel Orientation="Horizontal" HorizontalAlignment="Left" VerticalAlignment="Top">
        <Button Margin="5"
                ContentTemplate="{StaticResource ButtonContentTemplate}"/>
        <ToggleButton Margin="5"
                  ContentTemplate="{StaticResource ButtonContentTemplate}"/>
        <CheckBox Margin="5"
                  ContentTemplate="{StaticResource ButtonContentTemplate}"/>
        <RadioButton Margin="5"
                     ContentTemplate="{StaticResource ButtonContentTemplate}"/>
    </StackPanel>
```

## 4. Trigger

- ```TriggerBase```를 상속한다.
- 조건을 설정하고, 조건 만족시 변경할 상태(or Action)를 정의.
- 조건 불만족 시 이전 상태로 복귀.
- 주요 프로퍼티

| Name | Type | Note |
|:-----|:-----|:-----|
| `Property` | `DependencyProperty` | 감시 대상(Control)의 Property(DependencyProperty) |
| `Value` | `object` | 설정한 `Property` 와 비교할 값 |
| `Setters` | `SetterBaseCollection` | Trigger 조건 만족 시 적용할 Setter 목록 (복수 Setter 설정 가능) |

```xml
<Button Content="버튼">
    <Button.Style>
        <Style TargetType="{x:Type Button}">
            <Style.Triggers>
            
                <!-- Trigger 1. 감시 대상 Button의 IsMouseOver 값이 True 일 때 -->
                <!-- Foreground = Red, Cursor = Hand 로 변경 -->
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Foreground" Value="Red"/>
                    <Setter Property="Cursor" Value="Hand"/>
                </Trigger>
                
                <!-- Trigger 2. 감시 대상 Button의 IsPressed 값이 True 일 때 -->
                <!-- Foreground = White 로 변경 -->
                <Trigger Property="IsPressed" Value="True">
                    <Setter Property="Foreground" Value="White"/>
                    
                    <!-- Setters 태그 생략 가능
                    <Trigger.Setters>
                        <Setter Property="Foreground" Value="White"/>
                    </Trigger.Setters>
                    -->
                </Trigger>
                
            </Style.Triggers>
        </Style>
    </Button.Style>
</Button>
```


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


- ```ContentControl``` 클래스를 상속받는 Control 목록 (작성 중...)

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

