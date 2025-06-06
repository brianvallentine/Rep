using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1 : QueryBasis<R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT T1.SITUACAO
            INTO :CBAPOVIG-SITUACAO
            FROM SEGUROS.CB_APOLICE_VIGPROP T1
            WHERE T1.NUM_APOLICE = :V1PARC-NUM-APOL
            AND T1.NUM_ENDOSSO = :V1PARC-NRENDOS
            AND T1.SITUACAO = 'V'
            AND T1.NUM_PARCELA =
            (SELECT MIN(T2.NUM_PARCELA)
            FROM SEGUROS.CB_APOLICE_VIGPROP T2
            WHERE T2.NUM_APOLICE = T1.NUM_APOLICE
            AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT T1.SITUACAO
											FROM SEGUROS.CB_APOLICE_VIGPROP T1
											WHERE T1.NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND T1.NUM_ENDOSSO = '{this.V1PARC_NRENDOS}'
											AND T1.SITUACAO = 'V'
											AND T1.NUM_PARCELA =
											(SELECT MIN(T2.NUM_PARCELA)
											FROM SEGUROS.CB_APOLICE_VIGPROP T2
											WHERE T2.NUM_APOLICE = T1.NUM_APOLICE
											AND T2.NUM_ENDOSSO = T1.NUM_ENDOSSO)
											WITH UR";

            return query;
        }
        public string CBAPOVIG_SITUACAO { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1 Execute(R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1 r3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1)
        {
            var ths = r3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3500_00_SELECT_CBAPOVIG_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBAPOVIG_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}