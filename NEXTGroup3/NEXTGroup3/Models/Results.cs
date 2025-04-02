namespace NEXTGroup3.Models
{
  public class Results
  {
    // Results List
    private List<Result> resultsList;
    public List<Result> ResultsList { get { return resultsList; } set { resultsList = value; } }

    // Candidate ID
    private int candidateId;
    public int CandidateId { get { return candidateId; } set { candidateId = value; } }

    // Result
    private string result;
    public string Result { get { return result; } set { result = value; } }

    // Candidate
    private int candidate;
    public int Candidate { get { return candidate; } set { candidate = value; } }

    // Add result
    public void addResult(Result result)
    {

    }

  }
}
