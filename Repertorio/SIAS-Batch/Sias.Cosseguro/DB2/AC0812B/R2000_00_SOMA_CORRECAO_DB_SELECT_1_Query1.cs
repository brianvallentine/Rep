using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0812B
{
    public class R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1 : QueryBasis<R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(SUM(PRM_TARIFARIO),+0) ,
            VALUE(SUM(VAL_DESCONTO),+0) ,
            VALUE(SUM(VLPRMLIQ),+0) ,
            VALUE(SUM(VLADIFRA),+0) ,
            VALUE(SUM(VLCOMIS),+0) ,
            VALUE(SUM(VLPRMTOT),+0)
            INTO
            :V2CHIS-PRM-TARF ,
            :V2CHIS-VAL-DESC ,
            :V2CHIS-VLPRMLIQ ,
            :V2CHIS-VLADIFRA ,
            :V2CHIS-VLCOMISS ,
            :V2CHIS-VLPRMTOT
            FROM
            SEGUROS.V0COSSEG_HISTPRE
            WHERE
            CONGENER = :V1CHIS-CONGENER
            AND NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            AND NRPARCEL = :V1CHIS-NRPARCEL
            AND OPERACAO = :WHOST-OPERACAO
            AND TIPSGU = '1'
            AND NUMOCOR = :V1CHIS-NUM-OCOR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(PRM_TARIFARIO)
							,+0) 
							,
											VALUE(SUM(VAL_DESCONTO)
							,+0) 
							,
											VALUE(SUM(VLPRMLIQ)
							,+0) 
							,
											VALUE(SUM(VLADIFRA)
							,+0) 
							,
											VALUE(SUM(VLCOMIS)
							,+0) 
							,
											VALUE(SUM(VLPRMTOT)
							,+0)
											FROM
											SEGUROS.V0COSSEG_HISTPRE
											WHERE
											CONGENER = '{this.V1CHIS_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'
											AND NRPARCEL = '{this.V1CHIS_NRPARCEL}'
											AND OPERACAO = '{this.WHOST_OPERACAO}'
											AND TIPSGU = '1'
											AND NUMOCOR = '{this.V1CHIS_NUM_OCOR}'";

            return query;
        }
        public string V2CHIS_PRM_TARF { get; set; }
        public string V2CHIS_VAL_DESC { get; set; }
        public string V2CHIS_VLPRMLIQ { get; set; }
        public string V2CHIS_VLADIFRA { get; set; }
        public string V2CHIS_VLCOMISS { get; set; }
        public string V2CHIS_VLPRMTOT { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }
        public string V1CHIS_NUM_OCOR { get; set; }
        public string WHOST_OPERACAO { get; set; }

        public static R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1 Execute(R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1 r2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_SOMA_CORRECAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V2CHIS_PRM_TARF = result[i++].Value?.ToString();
            dta.V2CHIS_VAL_DESC = result[i++].Value?.ToString();
            dta.V2CHIS_VLPRMLIQ = result[i++].Value?.ToString();
            dta.V2CHIS_VLADIFRA = result[i++].Value?.ToString();
            dta.V2CHIS_VLCOMISS = result[i++].Value?.ToString();
            dta.V2CHIS_VLPRMTOT = result[i++].Value?.ToString();
            return dta;
        }

    }
}