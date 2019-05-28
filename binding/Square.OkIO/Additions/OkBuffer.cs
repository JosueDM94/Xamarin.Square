using Java.Interop;

namespace Square.OkIO
{
    partial class OkBuffer : global::Java.Lang.Object, global::Java.Lang.ICloneable, global::Java.Nio.Channels.IByteChannel, global::Square.OkIO.IBufferedSink, global::Square.OkIO.IBufferedSource
    {
        global::Square.OkIO.OkBuffer IBufferedSink.Buffer()
        {
            return this;
        }
    }
}