class UnionFind {
  ids: Array<number> = []
  rank: Array<number> = []

  constructor(N) {
    for (let i = 0; i < N; i++) {
      this.ids[i] = i
      this.rank[i] = 0
    }
  }

  private root(i): number {
    if (i != this.ids[i]) {
      // path compression
      this.ids[i] = this.root(this.ids[i])
    }
    return this.ids[i]
  }

  public find(p: number, q: number): boolean {
    return this.root(p) == this.root(q)
  }

  public union(p: number, q: number) {
    const pRoot = this.root(p)
    const qRoot = this.root(q)

    // Already connected
    if (pRoot === qRoot) return 

    if (this.rank[pRoot] > this.rank[qRoot]) {
      this.ids[qRoot] = pRoot
    } else if (this.rank[pRoot] < this.rank[qRoot]) {
      this.ids[pRoot] = qRoot
    } else {
      this.ids[qRoot] = pRoot
      this.rank[pRoot] += 1
    }
  }
}

const unionFind = new UnionFind(6)
unionFind.union(1, 2)
unionFind.union(3, 2)
unionFind.union(1, 3)
unionFind.union(1, 4)
unionFind.union(4, 5)
unionFind.find(1, 3) //?
unionFind.find(1, 2) //?
unionFind.find(1, 5) //?
unionFind.find(5, 4) //?

