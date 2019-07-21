using TheAwesomeTextAdventure.Infrastructure.Writers.Abstractions;
using TheAwesomeTextAdventure.Processor.Abstractions;

namespace TheAwesomeTextAdventure.Processor
{
    public class RoomsProcessor : BaseProcessor, IRoomsProcessor
    {
        public RoomsProcessor(IPlayerWriter playerWriter) : base(playerWriter)
        {
        }

        public void StartProcessing(object player)
        {
            throw new System.NotImplementedException();
        }
    }
}
