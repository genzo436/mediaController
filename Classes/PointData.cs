namespace mediaController.Classes
{
  class PointData
  {
    bool[] points;
    int validpoints = 0;
    public PointData(int length)
    {
      points = new bool[length];
    }

    public int PointCount
    {
      get
      {
        return validpoints;
      }
    }

    public void SetPoint(int pos, bool state)
    {
      if (points[pos] != state)
      {
        if (state)
          validpoints++;
        else
          validpoints--;
      }
      points[pos] = state;
    }
    public bool this[int pos]
    {
      get
      {
        return points[pos];
      }
    }
  }
}
