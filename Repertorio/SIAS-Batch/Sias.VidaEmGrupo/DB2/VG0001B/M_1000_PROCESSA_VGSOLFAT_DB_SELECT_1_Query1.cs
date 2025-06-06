using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1 : QueryBasis<M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            COD_CLIENTE,
            OCORR_ENDERECO,
            PERI_FATURAMENTO,
            TIPO_FATURAMENTO,
            AGE_COBRANCA,
            OPCAO_COBERTURA,
            DATA_INIVIGENCIA,
            TIPO_SUBGRUPO,
            VALUE(IND_IOF, 'S' )
            INTO :SUBGVGAP-COD-FONTE,
            :SUBGVGAP-COD-CLIENTE,
            :SUBGVGAP-OCORR-ENDERECO,
            :SUBGVGAP-PERI-FATURAMENTO,
            :SUBGVGAP-TIPO-FATURAMENTO,
            :SUBGVGAP-AGE-COBRANCA,
            :SUBGVGAP-OPCAO-COBERTURA,
            :SUBGVGAP-DATA-INIVIGENCIA,
            :SUBGVGAP-TIPO-SUBGRUPO,
            :SUBGVGAP-IND-IOF
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											COD_CLIENTE
							,
											OCORR_ENDERECO
							,
											PERI_FATURAMENTO
							,
											TIPO_FATURAMENTO
							,
											AGE_COBRANCA
							,
											OPCAO_COBERTURA
							,
											DATA_INIVIGENCIA
							,
											TIPO_SUBGRUPO
							,
											VALUE(IND_IOF
							, 'S' )
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_TIPO_FATURAMENTO { get; set; }
        public string SUBGVGAP_AGE_COBRANCA { get; set; }
        public string SUBGVGAP_OPCAO_COBERTURA { get; set; }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_TIPO_SUBGRUPO { get; set; }
        public string SUBGVGAP_IND_IOF { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1 Execute(M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1 m_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1)
        {
            var ths = m_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_PROCESSA_VGSOLFAT_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.SUBGVGAP_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_SUBGRUPO = result[i++].Value?.ToString();
            dta.SUBGVGAP_IND_IOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}