using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1000B
{
    public class R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1 : QueryBasis<R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(PRM_TARIFARIO),
            SUM(VAL_DESCONTO) ,
            SUM(VLPRMLIQ) ,
            SUM(VLADIFRA) ,
            SUM(VLCUSEMI) ,
            SUM(VLIOCC) ,
            SUM(VLPRMTOT)
            INTO :W1-PRM-TAR ,
            :W1-VAL-DES ,
            :W1-VLPRMLIQ ,
            :W1-VLADIFRA ,
            :W1-VLCUSEMI ,
            :W1-VLIOCC ,
            :W1-VLPRMTOT
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND NRPARCEL = :V1PARC-NRPARCEL
            AND OPERACAO IN (0101,0801)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(PRM_TARIFARIO)
							,
											SUM(VAL_DESCONTO) 
							,
											SUM(VLPRMLIQ) 
							,
											SUM(VLADIFRA) 
							,
											SUM(VLCUSEMI) 
							,
											SUM(VLIOCC) 
							,
											SUM(VLPRMTOT)
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND NRPARCEL = '{this.V1PARC_NRPARCEL}'
											AND OPERACAO IN (0101
							,0801)";

            return query;
        }
        public string W1_PRM_TAR { get; set; }
        public string W1_VAL_DES { get; set; }
        public string W1_VLPRMLIQ { get; set; }
        public string W1_VLADIFRA { get; set; }
        public string W1_VLCUSEMI { get; set; }
        public string W1_VLIOCC { get; set; }
        public string W1_VLPRMTOT { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1 Execute(R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1 r3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1)
        {
            var ths = r3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3100_00_SALDO_ANTERIOR_DB_SELECT_1_Query1();
            var i = 0;
            dta.W1_PRM_TAR = result[i++].Value?.ToString();
            dta.W1_VAL_DES = result[i++].Value?.ToString();
            dta.W1_VLPRMLIQ = result[i++].Value?.ToString();
            dta.W1_VLADIFRA = result[i++].Value?.ToString();
            dta.W1_VLCUSEMI = result[i++].Value?.ToString();
            dta.W1_VLIOCC = result[i++].Value?.ToString();
            dta.W1_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}