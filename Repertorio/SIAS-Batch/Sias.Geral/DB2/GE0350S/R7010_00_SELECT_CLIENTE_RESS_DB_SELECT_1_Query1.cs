using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0350S
{
    public class R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1 : QueryBasis<R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_CPFCGC_ACORDO,
            NOM_RESP_ACORDO,
            DES_ENDERECO,
            NOM_CIDADE,
            COD_UF,
            NUM_CEP,
            COD_FONTE,
            TIPO_PESSOA
            INTO :SIARDEVC-NUM-CPFCGC-ACORDO,
            :SIARDEVC-NOM-RESP-ACORDO,
            :SIARDEVC-DES-ENDERECO,
            :SIARDEVC-NOM-CIDADE,
            :SIARDEVC-COD-UF,
            :SIARDEVC-NUM-CEP,
            :SIARDEVC-COD-FONTE,
            :SIARDEVC-TIPO-PESSOA
            FROM SEGUROS.SI_AR_DETALHE_VC
            WHERE NOM_ARQUIVO = 'SCMOVSIN'
            AND NUM_RESSARC = :SIARDEVC-NUM-RESSARC
            AND NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND COD_OPERACAO = 4000
            AND NUM_PARCELA_ACORDO= :SIARDEVC-NUM-PARCELA-ACORDO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_CPFCGC_ACORDO
							,
											NOM_RESP_ACORDO
							,
											DES_ENDERECO
							,
											NOM_CIDADE
							,
											COD_UF
							,
											NUM_CEP
							,
											COD_FONTE
							,
											TIPO_PESSOA
											FROM SEGUROS.SI_AR_DETALHE_VC
											WHERE NOM_ARQUIVO = 'SCMOVSIN'
											AND NUM_RESSARC = '{this.SIARDEVC_NUM_RESSARC}'
											AND NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND COD_OPERACAO = 4000
											AND NUM_PARCELA_ACORDO= '{this.SIARDEVC_NUM_PARCELA_ACORDO}'";

            return query;
        }
        public string SIARDEVC_NUM_CPFCGC_ACORDO { get; set; }
        public string SIARDEVC_NOM_RESP_ACORDO { get; set; }
        public string SIARDEVC_DES_ENDERECO { get; set; }
        public string SIARDEVC_NOM_CIDADE { get; set; }
        public string SIARDEVC_COD_UF { get; set; }
        public string SIARDEVC_NUM_CEP { get; set; }
        public string SIARDEVC_COD_FONTE { get; set; }
        public string SIARDEVC_TIPO_PESSOA { get; set; }
        public string SIARDEVC_NUM_PARCELA_ACORDO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_NUM_RESSARC { get; set; }

        public static R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1 Execute(R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1 r7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1)
        {
            var ths = r7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7010_00_SELECT_CLIENTE_RESS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SIARDEVC_NUM_CPFCGC_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_RESP_ACORDO = result[i++].Value?.ToString();
            dta.SIARDEVC_DES_ENDERECO = result[i++].Value?.ToString();
            dta.SIARDEVC_NOM_CIDADE = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_UF = result[i++].Value?.ToString();
            dta.SIARDEVC_NUM_CEP = result[i++].Value?.ToString();
            dta.SIARDEVC_COD_FONTE = result[i++].Value?.ToString();
            dta.SIARDEVC_TIPO_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}