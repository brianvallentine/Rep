using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class A5000_LE_APOLITEM_DB_SELECT_1_Query1 : QueryBasis<A5000_LE_APOLITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT COUNT(*),
            SUM(PRM_TARIFARIO_IX)
            INTO :APIT-QTITENS:VIND-QTITENS,
            :APIT-TARIFARIO-IX:VIND-TARIFARIO
            FROM SEGUROS.V1APOLITEM
            WHERE NUM_APOLICE = :ENDO-NUM-APOLICE
            AND NRENDOS = :ENDO-NRENDOS
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
							,
											SUM(PRM_TARIFARIO_IX)
											FROM SEGUROS.V1APOLITEM
											WHERE NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND NRENDOS = '{this.ENDO_NRENDOS}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string APIT_QTITENS { get; set; }
        public string VIND_QTITENS { get; set; }
        public string APIT_TARIFARIO_IX { get; set; }
        public string VIND_TARIFARIO { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_NRENDOS { get; set; }

        public static A5000_LE_APOLITEM_DB_SELECT_1_Query1 Execute(A5000_LE_APOLITEM_DB_SELECT_1_Query1 a5000_LE_APOLITEM_DB_SELECT_1_Query1)
        {
            var ths = a5000_LE_APOLITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A5000_LE_APOLITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A5000_LE_APOLITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.APIT_QTITENS = result[i++].Value?.ToString();
            dta.VIND_QTITENS = string.IsNullOrWhiteSpace(dta.APIT_QTITENS) ? "-1" : "0";
            dta.APIT_TARIFARIO_IX = result[i++].Value?.ToString();
            dta.VIND_TARIFARIO = string.IsNullOrWhiteSpace(dta.APIT_TARIFARIO_IX) ? "-1" : "0";
            return dta;
        }

    }
}