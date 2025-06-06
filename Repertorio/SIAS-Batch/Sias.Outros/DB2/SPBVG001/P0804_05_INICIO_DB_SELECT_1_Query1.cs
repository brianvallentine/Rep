using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG001
{
    public class P0804_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0804_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT E.NUM_PROPOSTA_SIVPF,
            A.NUM_CERTIFICADO,
            D.CGCCPF,
            B.CAP_BAS_SEGURADO,
            B.VALOR_TITULO,
            B.DATA_SOLICITACAO,
            A.DATA_QUITACAO
            INTO :VG103-NUM-PROPOSTA
            ,:VG103-NUM-CERTIFICADO
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            FROM SEGUROS.PROPOSTAS_VA A,
            SEGUROS.VG_SOLICITA_FATURA B,
            SEGUROS.CLIENTES D,
            SEGUROS.CONVERSAO_SICOB E
            WHERE A.NUM_CERTIFICADO = :VGSOLFAT-NUM-TITULO
            AND A.NUM_APOLICE = B.NUM_APOLICE
            AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
            AND A.COD_CLIENTE = D.COD_CLIENTE
            AND A.NUM_APOLICE = E.NUM_SICOB
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT E.NUM_PROPOSTA_SIVPF
							,
											A.NUM_CERTIFICADO
							,
											D.CGCCPF
							,
											B.CAP_BAS_SEGURADO
							,
											B.VALOR_TITULO
							,
											B.DATA_SOLICITACAO
							,
											A.DATA_QUITACAO
											FROM SEGUROS.PROPOSTAS_VA A
							,
											SEGUROS.VG_SOLICITA_FATURA B
							,
											SEGUROS.CLIENTES D
							,
											SEGUROS.CONVERSAO_SICOB E
											WHERE A.NUM_CERTIFICADO = '{this.VGSOLFAT_NUM_TITULO}'
											AND A.NUM_APOLICE = B.NUM_APOLICE
											AND A.COD_SUBGRUPO = B.COD_SUBGRUPO
											AND A.COD_CLIENTE = D.COD_CLIENTE
											AND A.NUM_APOLICE = E.NUM_SICOB
											WITH UR";

            return query;
        }
        public string VG103_NUM_PROPOSTA { get; set; }
        public string VG103_NUM_CERTIFICADO { get; set; }
        public string VG103_NUM_CPF_CNPJ { get; set; }
        public string VG103_VLR_IS { get; set; }
        public string VG103_VLR_PREMIO { get; set; }
        public string VG103_DTA_OCORRENCIA { get; set; }
        public string VG103_DTA_RCAP { get; set; }
        public string VGSOLFAT_NUM_TITULO { get; set; }

        public static P0804_05_INICIO_DB_SELECT_1_Query1 Execute(P0804_05_INICIO_DB_SELECT_1_Query1 p0804_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0804_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0804_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0804_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG103_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.VG103_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.VG103_NUM_CPF_CNPJ = result[i++].Value?.ToString();
            dta.VG103_VLR_IS = result[i++].Value?.ToString();
            dta.VG103_VLR_PREMIO = result[i++].Value?.ToString();
            dta.VG103_DTA_OCORRENCIA = result[i++].Value?.ToString();
            dta.VG103_DTA_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}