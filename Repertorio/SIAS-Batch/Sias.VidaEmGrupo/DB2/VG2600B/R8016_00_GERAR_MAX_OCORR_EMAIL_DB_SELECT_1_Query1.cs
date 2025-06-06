using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1 : QueryBasis<R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(SEQ_EMAIL),0) + 1
            INTO :CLIENEMA-SEQ-EMAIL
            FROM SEGUROS.CLIENTE_EMAIL
            WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(SEQ_EMAIL)
							,0) + 1
											FROM SEGUROS.CLIENTE_EMAIL
											WHERE COD_CLIENTE = '{this.ENDERECO_COD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIENEMA_SEQ_EMAIL { get; set; }
        public string ENDERECO_COD_CLIENTE { get; set; }

        public static R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1 Execute(R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1 r8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1)
        {
            var ths = r8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8016_00_GERAR_MAX_OCORR_EMAIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.CLIENEMA_SEQ_EMAIL = result[i++].Value?.ToString();
            return dta;
        }

    }
}