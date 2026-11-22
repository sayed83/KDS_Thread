/* =====================================================================
   Dynamic Report Generator (frmDynamicReportGen) – setup
   Safe to run more than once.
   ===================================================================== */

/* 1. Optional columns on ReportParameters (the form also works without them) */
IF COL_LENGTH('dbo.ReportParameters', 'DisplayLabel') IS NULL
    ALTER TABLE dbo.ReportParameters ADD DisplayLabel NVARCHAR(100) NULL;   -- caption shown on screen
IF COL_LENGTH('dbo.ReportParameters', 'LookupQuery') IS NULL
    ALTER TABLE dbo.ReportParameters ADD LookupQuery NVARCHAR(MAX) NULL;    -- for UIType = Combo: SELECT Id, Name ...
IF COL_LENGTH('dbo.ReportParameters', 'DefaultValue') IS NULL
    ALTER TABLE dbo.ReportParameters ADD DefaultValue NVARCHAR(200) NULL;   -- Date: day offset / MonthStart / MonthEnd; Combo: value
IF COL_LENGTH('dbo.ReportParameters', 'SortOrder') IS NULL
    ALTER TABLE dbo.ReportParameters ADD SortOrder INT NULL;                -- display order
GO

/* 2. UIType reference
     Date | Combo | Unit | Rep | Text | Number | Decimal | Check | Hidden
     Hidden = not shown on screen; always passes DefaultValue ('0' -> 0, '' -> '').
     Rep = Representative dropdown (T_Get_RepresentativeDropdown, 'All' = 0),
           reloads automatically when the Unit dropdown changes.
   ParameterName must match the stored-procedure parameter (e.g. @FromDate).
   The same value is also passed to the Crystal parameter of the same name
   (with or without '@') if it exists in the .rpt.                         */

/* 3. Report 1 – Schedule Balance Representative Summary
      SP: T_Rpt_Reprs_ScheduleBalance_Proc_New
          (@RepId, @Unit, @Zone, @CusId, @ProductId, @RetailerId, @Shade)
      Only Unit + Sales Rep. are shown; the rest are Hidden with fixed defaults. */
/*    Report 2 – Schedule Balance Count Summary: same procedure, grouped by count (ProductName). */
UPDATE dbo.ReportMaster
SET QueryType = 'StoredProcedure',
    QueryString = 'T_Rpt_Reprs_ScheduleBalance_Proc_New',
    ReportPath = '\Report\Repres_ScheduleBalance_RepSummary.rpt'   -- Rep name + total balance only
WHERE ReportId = 1;

UPDATE dbo.ReportMaster
SET QueryType = 'StoredProcedure',
    QueryString = 'T_Rpt_Reprs_ScheduleBalance_Proc_New',
    ReportPath = '\Report\Count_ScheduleBalance_Summary.rpt'       -- Count name + total balance only
WHERE ReportId = 2;

DELETE FROM dbo.ReportParameters WHERE ReportId IN (1, 2);

-- Zone / CusId / ProductId / RetailerId / Shade are not listed: the form fills them with 0 / '' automatically.
INSERT INTO dbo.ReportParameters (ReportId, ParameterName, UIType, IsActive, DisplayLabel, DefaultValue, SortOrder)
VALUES
 (1, '@Unit',  'Unit', 1, 'Unit',       '0', 1),
 (1, '@RepId', 'Rep',  1, 'Sales Rep.', '0', 2),
 (2, '@Unit',  'Unit', 1, 'Unit',       '0', 1),
 (2, '@RepId', 'Rep',  1, 'Sales Rep.', '0', 2);
GO
