using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Exercise3;

// ── TradeRecord.cs ──
public record TradeRecord(
    string Isin,
    string Cusip,
    string Instrument,
    int Quantity,
    decimal Price,
    DateOnly TradeDate
);
