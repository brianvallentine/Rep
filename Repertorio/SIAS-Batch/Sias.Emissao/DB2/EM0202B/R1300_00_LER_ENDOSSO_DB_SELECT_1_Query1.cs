using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_ENDOSSO
            ,RAMO
            ,CODPRODU
            ,OCORR_ENDERECO
            INTO :V1ENDO-TIPO-END
            ,:V1ENDO-RAMO
            ,:V1ENDO-CODPRODU
            ,:V1ENDO-OCORREND
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V1EDIA-NUM-APOL
            AND NRENDOS = :V1EDIA-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_ENDOSSO
											,RAMO
											,CODPRODU
											,OCORR_ENDERECO
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V1EDIA_NUM_APOL}'
											AND NRENDOS = '{this.V1EDIA_NRENDOS}'";

            return query;
        }
        public string V1ENDO_TIPO_END { get; set; }
        public string V1ENDO_RAMO { get; set; }
        public string V1ENDO_CODPRODU { get; set; }
        public string V1ENDO_OCORREND { get; set; }
        public string V1EDIA_NUM_APOL { get; set; }
        public string V1EDIA_NRENDOS { get; set; }

        public static R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1 Execute(R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1 r1300_00_LER_ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_LER_ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ENDO_TIPO_END = result[i++].Value?.ToString();
            dta.V1ENDO_RAMO = result[i++].Value?.ToString();
            dta.V1ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.V1ENDO_OCORREND = result[i++].Value?.ToString();
            return dta;
        }

    }
}