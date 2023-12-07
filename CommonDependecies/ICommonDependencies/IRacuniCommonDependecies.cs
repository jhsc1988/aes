using aes.Services.RacuniServices.IServices;
using aes.Services.RacuniServices.IServices.IRacuniService;

namespace aes.CommonDependecies.ICommonDependencies
{
    public interface IRacuniCommonDependecies : ICommonDependencies
    {
        IRacuniInlineEditorService RacuniInlineEditorService { get; }
        IRacuniTempEditorService RacuniTempEditorService { get; }
        IService Service { get; }
        IRacuniCheckService RacuniCheckService { get; }
    }
}