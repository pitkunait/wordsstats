import sys
import plotly.graph_objects as go
from plotly.subplots import make_subplots

if __name__ == '__main__':

    with open(sys.argv[1], "r") as f:
        lines = f.readlines()[1:]
        lines = [i.strip("\n").strip("%").split(" ") for i in lines]

    fig = make_subplots(rows=1, cols=1, specs=[[{'type': 'domain'}]])

    fig.add_trace(go.Bar(x=[i[0] for i in lines],
                         y=[float(i[1]) for i in lines],
                         text=[float(i[1]) for i in lines],
                         texttemplate="%{text:.2f}%",
                         textposition='outside',
                         ))
    fig.write_image(engine="kaleido", file=f"plot.png")
    fig.show()