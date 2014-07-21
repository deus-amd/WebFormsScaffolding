﻿Imports System.ComponentModel.DataAnnotations

Public Partial Class DateTime_EditField
	Inherits System.Web.DynamicData.FieldTemplateUserControl
	Private Shared DefaultDateAttribute As New DataTypeAttribute(DataType.DateTime)

	Protected Sub Page_Init(sender As Object, e As EventArgs)
		TextBox1.ToolTip = Column.Description
		Label1.Text = Column.DisplayName
	End Sub

	' show bootstrap has-error
	Protected Sub Page_PreRender(sender As Object, e As EventArgs)
		' if validation error then apply bootstrap has-error CSS class
		Dim isValid = Me.Page.ModelState.IsValidField(Column.Name)
		Div1.Attributes("class") = If(isValid, "form-group", "form-group has-error")
	End Sub


	Protected Overrides Sub ExtractValues(dictionary As IOrderedDictionary)
		dictionary(Column.Name) = ConvertEditedValue(TextBox1.Text)
	End Sub

	Public Overrides ReadOnly Property DataControl() As Control
		Get
			Return TextBox1
		End Get
	End Property

End Class