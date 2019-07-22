using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Processors.Abstractions;
using TheAwesomeTextAdventure.Services.Abstractions;

namespace TheAwesomeTextAdventure.Processors
{
    public class RoomsProcessor : BaseProcessor, IRoomsProcessor
    {
        public RoomsProcessor(
            IPlayerWriter playerWriter,
            IActionWrapper actionWrapper,
            IExitWrapper exitWrapper) : base(playerWriter, actionWrapper, exitWrapper)
        {
        }

        public void StartProcessing(object player)
        {
            throw new System.NotImplementedException();
        }
    }
}
