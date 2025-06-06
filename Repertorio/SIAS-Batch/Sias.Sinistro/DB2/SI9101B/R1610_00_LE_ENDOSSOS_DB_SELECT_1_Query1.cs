using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9101B
{
    public class R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1 : QueryBasis<R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            INTO :ENDOSSOS-DATA-INIVIGENCIA
            FROM SEGUROS.ENDOSSOS A
            WHERE A.NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND A.TIPO_ENDOSSO = '5'
            AND A.SIT_REGISTRO <> '2'
            AND A.DATA_EMISSAO =
            (SELECT MAX(B.DATA_EMISSAO)
            FROM SEGUROS.ENDOSSOS B
            WHERE A.NUM_APOLICE = B.NUM_APOLICE
            AND B.TIPO_ENDOSSO = '5'
            AND B.SIT_REGISTRO <> '2' )
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											FROM SEGUROS.ENDOSSOS A
											WHERE A.NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND A.TIPO_ENDOSSO = '5'
											AND A.SIT_REGISTRO <> '2'
											AND A.DATA_EMISSAO =
											(SELECT MAX(B.DATA_EMISSAO)
											FROM SEGUROS.ENDOSSOS B
											WHERE A.NUM_APOLICE = B.NUM_APOLICE
											AND B.TIPO_ENDOSSO = '5'
											AND B.SIT_REGISTRO <> '2' )";

            return query;
        }
        public string ENDOSSOS_DATA_INIVIGENCIA { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1 Execute(R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1 r1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1)
        {
            var ths = r1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1610_00_LE_ENDOSSOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.ENDOSSOS_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}