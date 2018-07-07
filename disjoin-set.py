class Nodo(object):
	def __init__(self,val,i):
		super(Nodo, self).__init__()
		self.padre = self
		self.val = val
		self.i = i

class Grafo(object):
	nodos = []
	def __init__(self,arr):
		super(Grafo, self).__init__()
		i=0
		for x in arr: # llenado
			self.nodos.append(Nodo(x,i))
			i+=1
	def UnionSet(self,ia, ib):
		a = self.GetTopPadre(self.nodos[ia]) #1|2
		b = self.GetTopPadre(self.nodos[ib]) #3|9
		for x in self.nodos:
			if self.GetTopPadre(x) == b:
				x.padre = self.GetTopPadre(a)
	def GetTopPadre(self, nodo):
		if nodo == nodo.padre:
			return nodo
		else:
			return self.GetTopPadre(nodo.padre)
	def ShowArr(self):
		r = ""
		for x in self.nodos:
			r=r+str(x.val)+" "
		r += "\n"
		for x in self.nodos:
			r=r+str(self.GetTopPadre(x).i)+" "
		print (r)

arr = [5,2,1,9,6,8,0]
	 # 0 1 2 3 4 5 6
g = Grafo(arr)
g.UnionSet(1,3) # por indices
g.UnionSet(0,3)
g.UnionSet(2,4)
g.ShowArr()