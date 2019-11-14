import numpy as np
import pandas as pd
import pylab
import re

def render():
    import cv2
    import numpy as np
    import glob

    img_array = []
    for filename in sorted(glob.glob('cache/*.png'),key=lambda var:[int(x) if x.isdigit() else x for x in re.findall(r'[^0-9]|[0-9]+', var)]):
        print(filename)
        img = cv2.imread(filename)
        height, width, layers = img.shape
        size = (width, height)
        img_array.append(img)

    fourcc = cv2.VideoWriter_fourcc(*'mp4v')
    out = cv2.VideoWriter('my_project.mp4', fourcc, 24, frameSize=(640, 480))

    for i in range(len(img_array)):
        out.write(img_array[i])
    out.release()


ANIMATE = True

w_df = pd.read_csv('Wallaby.csv', delimiter=';')
a_df = pd.read_csv('AllBlack.csv', delimiter=';')

w_players = np.unique(w_df['ID'])
a_players = np.unique(a_df['ID'])

num_w_players = w_players.shape[0]
num_a_players = a_players.shape[0]

if ANIMATE:
    pylab.grid()
    pylab.xlim(0, 250)
    pylab.ylim(0, 250)

    pylab.plot(w_df['0_Position'][0], w_df['1_Position'][0], 'o', color='green', alpha=0.6, markersize=20)
    pylab.plot(a_df['0_Position'][0], a_df['1_Position'][0], 'o', color='green', alpha=0.6, markersize=20)

    #pylab.plot(w_df['0_Position'][0], w_df['1_Position'][0], '+', color='red', alpha=0.6, markersize=10)

    for ii in range(w_df.shape[0]):
        pylab.plot(w_df['0_Position'][ii], w_df['1_Position'][ii], 'o', color='green', alpha=0.6)
        pylab.plot(a_df['0_Position'][ii], a_df['1_Position'][ii], 'o', color='black', alpha=0.6)
        pylab.savefig(f'cache/w_game_{ii}.png')
        pylab.title(f'Frame {ii}')

    for p in w_players:
        idx = w_df['ID'] == p
        # pylab.plot(w_df['0_Position'][idx], w_df['1_Position'][idx], 'o', alpha=0.7, markersize=2, color='green')
        die = np.asanyarray([w_df['0_Position'][idx], w_df['1_Position'][idx]])

        pylab.plot(die[0][0], die[1][0], 'o', markersize=10, alpha=0.6, color='green')
        pylab.plot(die[0][-1], die[1][-1], '+', markersize=20, color='red')
        pylab.plot(die[0][-1], die[1][-1], 'o', markersize=15, alpha=0.6, color='red')

    #pylab.plot(w_df['0_Position'].iloc[-1], w_df['1_Position'].iloc[-1], '+', color='red', alpha=0.6, markersize=10)

    render()



    # for p in w_players:
    #     idx = w_df['ID'] == p
    #     path = np.asarray([w_df['0_Position'][idx], w_df['1_Position'][idx]])
    #     for ii in range(0, path.shape[1]):
    #         pylab.xlim(0, 250)
    #         pylab.ylim(0, 250)
    #         pylab.plot(path[0, ii], path[1, ii], 'o', alpha=0.7, markersize=2, color='green')
    #         pylab.savefig(f'cache/w_game_{ii}.png')
    # for p in a_players:
    #     idx = a_df['ID'] == p
    #     path = np.asarray([a_df['0_Position'][idx], a_df['1_Position'][idx]])
    #     for ii in range(0, path.shape[1]):
    #         pylab.xlim(0, 250)
    #         pylab.ylim(0, 250)
    #         pylab.plot(path[0, ii], path[1, ii], 'o', alpha=0.7, markersize=2, color='green')
    #
    #         pylab.savefig(f'cache/b_game_{ii}.png')
    # pylab.show()

else:
    for p in w_players:
        idx = w_df['ID'] == p
        pylab.plot(w_df['0_Position'][idx], w_df['1_Position'][idx], 'o', alpha=0.7, markersize=2, color='green')
        die = np.asanyarray([w_df['0_Position'][idx], w_df['1_Position'][idx]])

        pylab.plot(die[0][0], die[1][0], 'o', markersize=10, alpha=0.6, color='green')
        pylab.plot(die[0][-1], die[1][-1], '+', markersize=20, color='red')
        pylab.plot(die[0][-1], die[1][-1], 'o', markersize=15, alpha=0.6, color='red')

    for p in a_players:
        idx = a_df['ID'] == p
        pylab.plot(a_df['0_Position'][idx], a_df['1_Position'][idx], 'o', markersize=2, alpha=0.7, color='black')
        die = np.asanyarray([a_df['0_Position'][idx], a_df['1_Position'][idx]])

        pylab.plot(die[0][0], die[1][0], 'o', markersize=10, alpha=0.6, color='green')

    pylab.grid()
    pylab.show()
