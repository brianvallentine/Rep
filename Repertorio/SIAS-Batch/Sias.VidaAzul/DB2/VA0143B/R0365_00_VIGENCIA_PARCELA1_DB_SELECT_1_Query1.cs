using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0143B
{
    public class R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 : QueryBasis<R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT B.DATA_INIVIGENCIA
            ,B.PERI_PAGAMENTO
            INTO :WHOST-DTINI01
            ,:WHOST-PERI
            FROM SEGUROS.HIS_COBER_PROPOST A
            ,SEGUROS.OPCAO_PAG_VIDAZUL B
            WHERE A.NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND A.OCORR_HISTORICO = 1
            AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT B.DATA_INIVIGENCIA
											,B.PERI_PAGAMENTO
											FROM SEGUROS.HIS_COBER_PROPOST A
											,SEGUROS.OPCAO_PAG_VIDAZUL B
											WHERE A.NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND A.OCORR_HISTORICO = 1
											AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string WHOST_DTINI01 { get; set; }
        public string WHOST_PERI { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }

        public static R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 Execute(R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1)
        {
            var ths = r0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0365_00_VIGENCIA_PARCELA1_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTINI01 = result[i++].Value?.ToString();
            dta.WHOST_PERI = result[i++].Value?.ToString();
            return dta;
        }

    }
}