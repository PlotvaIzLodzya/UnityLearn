using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> _spells;

    private int _curentSpellIndex = 0;
    private Spell _currentSpell;

    public Spell CurrentSpell => _currentSpell;
    public List<Spell> Spells => _spells;

    private void Start()
    {
        ChangeSpell(_spells[_curentSpellIndex]);
    }

    public void NextSpell()
    {
        if (_spells.Count - 1 > _curentSpellIndex)
            _curentSpellIndex++;
        else if (_spells.Count - 1 == _curentSpellIndex)
            _curentSpellIndex = 0;

        ChangeSpell(_spells[_curentSpellIndex]);
    }

    public void PreviousSpell()
    {
        if (_curentSpellIndex > 0)
            _curentSpellIndex--;
        else if (_curentSpellIndex == 0)
            _curentSpellIndex = _spells.Count - 1;

        ChangeSpell(_spells[_curentSpellIndex]);
    }

    public void ChangeSpell(Spell spell)
    {
        _currentSpell = spell;
    }
}
