using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PRM_TARIFARIO),0) ,
            VALUE(SUM(VAL_DESCONTO),0) ,
            VALUE(SUM(VLPRMLIQ),0) ,
            VALUE(SUM(VLADIFRA),0) ,
            VALUE(SUM(VLCUSEMI),0) ,
            VALUE(SUM(VLIOCC),0) ,
            VALUE(SUM(VLPRMTOT),0) ,
            VALUE(SUM(VLPREMIO),0)
            INTO :WC-PRM-TAR ,
            :WC-VAL-DESC ,
            :WC-VLPRMLIQ ,
            :WC-VLADIFRA ,
            :WC-VLCUSEMI ,
            :WC-VLIOCC ,
            :WC-VLPRMTOT ,
            :WC-VLPREMIO
            FROM SEGUROS.V1HISTOPARC
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOS = :V1PARC-NRENDOS
            AND NRPARCEL = :V0HISP-NRPARCEL
            AND OPERACAO = 0801
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PRM_TARIFARIO)
							,0) 
							,
											VALUE(SUM(VAL_DESCONTO)
							,0) 
							,
											VALUE(SUM(VLPRMLIQ)
							,0) 
							,
											VALUE(SUM(VLADIFRA)
							,0) 
							,
											VALUE(SUM(VLCUSEMI)
							,0) 
							,
											VALUE(SUM(VLIOCC)
							,0) 
							,
											VALUE(SUM(VLPRMTOT)
							,0) 
							,
											VALUE(SUM(VLPREMIO)
							,0)
											FROM SEGUROS.V1HISTOPARC
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOS = '{this.V1PARC_NRENDOS}'
											AND NRPARCEL = '{this.V0HISP_NRPARCEL}'
											AND OPERACAO = 0801";

            return query;
        }
        public string WC_PRM_TAR { get; set; }
        public string WC_VAL_DESC { get; set; }
        public string WC_VLPRMLIQ { get; set; }
        public string WC_VLADIFRA { get; set; }
        public string WC_VLCUSEMI { get; set; }
        public string WC_VLIOCC { get; set; }
        public string WC_VLPRMTOT { get; set; }
        public string WC_VLPREMIO { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V0HISP_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 Execute(R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_ACUMULA_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WC_PRM_TAR = result[i++].Value?.ToString();
            dta.WC_VAL_DESC = result[i++].Value?.ToString();
            dta.WC_VLPRMLIQ = result[i++].Value?.ToString();
            dta.WC_VLADIFRA = result[i++].Value?.ToString();
            dta.WC_VLCUSEMI = result[i++].Value?.ToString();
            dta.WC_VLIOCC = result[i++].Value?.ToString();
            dta.WC_VLPRMTOT = result[i++].Value?.ToString();
            dta.WC_VLPREMIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}