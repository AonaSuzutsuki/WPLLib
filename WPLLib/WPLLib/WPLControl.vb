Imports System.Xml

Public Class WPLControl

    ''' <summary>
    ''' WPLファイルを生成します。
    ''' </summary>
    ''' <param name="savepath">保存先のパス</param>
    ''' <param name="mediapath">メディアパスが格納された配列</param>
    ''' <param name="Generator">WPLファイルの生成元の名前(デフォルト:KM-WPLLib)</param>
    ''' <remarks></remarks>
    Public Sub WPLCreate(ByVal savepath As String, ByVal mediapath As ArrayList, Optional ByVal Generator As String = "KM-WPLLib")
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xDeclaration As XmlProcessingInstruction = xDocument.CreateProcessingInstruction("wpl", "version=""1.0""")
        Dim xRoot As XmlElement = xDocument.CreateElement("smil")

        Dim xmeta As XmlElement

        'Head
        Dim header As XmlElement = xDocument.CreateElement("head")

        xmeta = xDocument.CreateElement("meta")
        xmeta.SetAttribute("name", "Generator")
        xmeta.SetAttribute("content", Generator)
        header.AppendChild(xmeta)

        xmeta = xDocument.CreateElement("meta")
        xmeta.SetAttribute("name", "ItemCount")
        xmeta.SetAttribute("content", mediapath.Count)
        header.AppendChild(xmeta)

        'Body
        Dim bodier As XmlElement = xDocument.CreateElement("body")
        Dim seqer As XmlElement = xDocument.CreateElement("seq")
        Dim xmedia As XmlElement

        For i = 0 To mediapath.Count - 1
            xmedia = xDocument.CreateElement("media")
            xmedia.SetAttribute("src", mediapath(i))
            seqer.AppendChild(xmedia)
        Next

        'seqの追加
        bodier.AppendChild(seqer)

        'ヘッダーとボディーの追加
        xRoot.AppendChild(header)
        xRoot.AppendChild(bodier)

        '宣言の追加
        xDocument.AppendChild(xDeclaration)
        'smilの追加
        xDocument.AppendChild(xRoot)

        xDocument.Save(savepath)

        xDeclaration = Nothing
        xRoot = Nothing
        xDocument = Nothing
    End Sub

    ''' <summary>
    ''' WPLファイルからメディアパスを取得します。
    ''' </summary>
    ''' <param name="wplpath">読み込み先のパス</param>
    ''' <returns>読み込み先から取り出したデータ</returns>
    ''' <remarks></remarks>
    Public Function WPLLoad(ByVal wplpath As String) As ArrayList
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xMediaList As XmlNodeList

        Dim media As New ArrayList

        xDocument.Load(wplpath)

        xRoot = xDocument.DocumentElement

        xDataList = xRoot.GetElementsByTagName("body")
        For Each xElement As XmlElement In xDataList
            xMediaList = xElement.GetElementsByTagName("media")
            For Each xMedia As XmlElement In xMediaList
                media.Add(xMedia.SelectSingleNode("@src").Value)
            Next xMedia
        Next xElement
        Return media
    End Function

    ''' <summary>
    ''' 指定されたインデックスにあるパスを返します。
    ''' </summary>
    ''' <param name="wplpath">読み込み先のパス</param>
    ''' <param name="index">インデックス値</param>
    ''' <returns>指定されたインデックスのメディアパス</returns>
    ''' <remarks></remarks>
    Public Function getFile(ByVal wplpath As String, ByVal index As UInteger) As String
        Dim media As New ArrayList
        media = WPLLoad(wplpath)

        Return media(index).ToString()
    End Function

    ''' <summary>
    ''' 指定されたインデックスのメディアパスを削除します。
    ''' </summary>
    ''' <param name="wplpath">保存先の</param>
    ''' <param name="index"></param>
    ''' <param name="Generator"></param>
    ''' <remarks></remarks>
    Public Sub RemoveAt(ByVal wplpath As String, ByVal index As UInteger, Optional ByVal Generator As String = "KM-WPLLib")
        Dim media As New ArrayList
        media = WPLLoad(wplpath)

        media.RemoveAt(index)

        WPLCreate(wplpath, media, Generator)
    End Sub
End Class
