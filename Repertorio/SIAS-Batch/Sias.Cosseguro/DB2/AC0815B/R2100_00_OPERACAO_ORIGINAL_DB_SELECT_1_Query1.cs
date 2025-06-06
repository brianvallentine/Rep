using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 : QueryBasis<R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PRM_TARIFARIO ,
            VAL_DESCONTO ,
            VLPRMLIQ ,
            VLADIFRA ,
            VLCOMIS ,
            VLPRMTOT ,
            DTQITBCO
            INTO
            :V1CHIS-PRM-TARF ,
            :V1CHIS-VAL-DESC ,
            :V1CHIS-VLPRMLIQ ,
            :V1CHIS-VLADIFRA ,
            :V1CHIS-VLCOMISS ,
            :V1CHIS-VLPRMTOT ,
            :V1CHIS-DTQITBCO:VIND-DAT-QTBC
            FROM
            SEGUROS.V0COSSEG_HISTPRE
            WHERE
            CONGENER = :V1CHIS-CONGENER
            AND NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            AND NRPARCEL = :V1CHIS-NRPARCEL
            AND OCORHIST = :V1CHIS-NUM-OCOR
            AND OPERACAO BETWEEN 0400 AND 0599
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PRM_TARIFARIO 
							,
											VAL_DESCONTO 
							,
											VLPRMLIQ 
							,
											VLADIFRA 
							,
											VLCOMIS 
							,
											VLPRMTOT 
							,
											DTQITBCO
											FROM
											SEGUROS.V0COSSEG_HISTPRE
											WHERE
											CONGENER = '{this.V1CHIS_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'
											AND NRPARCEL = '{this.V1CHIS_NRPARCEL}'
											AND OCORHIST = '{this.V1CHIS_NUM_OCOR}'
											AND OPERACAO BETWEEN 0400 AND 0599
											AND TIPSGU = '1'";

            return query;
        }
        public string V1CHIS_PRM_TARF { get; set; }
        public string V1CHIS_VAL_DESC { get; set; }
        public string V1CHIS_VLPRMLIQ { get; set; }
        public string V1CHIS_VLADIFRA { get; set; }
        public string V1CHIS_VLCOMISS { get; set; }
        public string V1CHIS_VLPRMTOT { get; set; }
        public string V1CHIS_DTQITBCO { get; set; }
        public string VIND_DAT_QTBC { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }
        public string V1CHIS_NUM_OCOR { get; set; }

        public static R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 Execute(R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 r2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_OPERACAO_ORIGINAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CHIS_PRM_TARF = result[i++].Value?.ToString();
            dta.V1CHIS_VAL_DESC = result[i++].Value?.ToString();
            dta.V1CHIS_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V1CHIS_VLADIFRA = result[i++].Value?.ToString();
            dta.V1CHIS_VLCOMISS = result[i++].Value?.ToString();
            dta.V1CHIS_VLPRMTOT = result[i++].Value?.ToString();
            dta.V1CHIS_DTQITBCO = result[i++].Value?.ToString();
            dta.VIND_DAT_QTBC = string.IsNullOrWhiteSpace(dta.V1CHIS_DTQITBCO) ? "-1" : "0";
            return dta;
        }

    }
}