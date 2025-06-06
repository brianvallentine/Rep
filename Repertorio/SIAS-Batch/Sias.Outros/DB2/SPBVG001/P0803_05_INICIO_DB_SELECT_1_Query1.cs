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
    public class P0803_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0803_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PF01A.NUM_PROPOSTA_SIVPF
            ,VG01A.NUM_TITULO
            ,CL01A.CGCCPF
            ,VG01A.CAP_BAS_SEGURADO
            ,VG01A.VALOR_TITULO
            ,VG01A.DATA_SOLICITACAO
            ,PF01A.DTQITBCO
            INTO :VG103-NUM-PROPOSTA
            ,:VG103-NUM-CERTIFICADO
            ,:VG103-NUM-CPF-CNPJ
            ,:VG103-VLR-IS
            ,:VG103-VLR-PREMIO
            ,:VG103-DTA-OCORRENCIA
            ,:VG103-DTA-RCAP
            FROM SEGUROS.VG_SOLICITA_FATURA VG01A
            ,SEGUROS.TERMO_ADESAO TA01A
            ,SEGUROS.PROPOSTA_FIDELIZ PF01A
            ,SEGUROS.CLIENTES CL01A
            WHERE VG01A.NUM_TITULO = :VGSOLFAT-NUM-TITULO
            AND TA01A.NUM_TERMO = VG01A.NUM_TITULO
            AND PF01A.NUM_SICOB = VG01A.NUM_TITULO
            AND CL01A.COD_CLIENTE = TA01A.COD_CLIENTE
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT PF01A.NUM_PROPOSTA_SIVPF
											,VG01A.NUM_TITULO
											,CL01A.CGCCPF
											,VG01A.CAP_BAS_SEGURADO
											,VG01A.VALOR_TITULO
											,VG01A.DATA_SOLICITACAO
											,PF01A.DTQITBCO
											FROM SEGUROS.VG_SOLICITA_FATURA VG01A
											,SEGUROS.TERMO_ADESAO TA01A
											,SEGUROS.PROPOSTA_FIDELIZ PF01A
											,SEGUROS.CLIENTES CL01A
											WHERE VG01A.NUM_TITULO = '{this.VGSOLFAT_NUM_TITULO}'
											AND TA01A.NUM_TERMO = VG01A.NUM_TITULO
											AND PF01A.NUM_SICOB = VG01A.NUM_TITULO
											AND CL01A.COD_CLIENTE = TA01A.COD_CLIENTE";

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

        public static P0803_05_INICIO_DB_SELECT_1_Query1 Execute(P0803_05_INICIO_DB_SELECT_1_Query1 p0803_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0803_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0803_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0803_05_INICIO_DB_SELECT_1_Query1();
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