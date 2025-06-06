using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0623B
{
    public class R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 : QueryBasis<R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_SUBGRUPO ,
            COD_CLIENTE ,
            CLASSE_APOLICE ,
            COD_FONTE ,
            TIPO_FATURAMENTO ,
            FORMA_FATURAMENTO ,
            FORMA_AVERBACAO ,
            TIPO_PLANO ,
            PERI_FATURAMENTO ,
            PERI_RENOVACAO ,
            PERI_RETROATI_INC ,
            PERI_RETROATI_CAN ,
            OCORR_ENDERECO ,
            OCORR_END_COBRAN ,
            BCO_COBRANCA ,
            AGE_COBRANCA ,
            DAC_COBRANCA ,
            TIPO_COBRANCA ,
            COD_PAG_ANGARIACAO ,
            PCT_CONJUGE_VG ,
            PCT_CONJUGE_AP ,
            OPCAO_COBERTURA ,
            OPCAO_CORRETAGEM ,
            IND_CONSISTE_MATRI ,
            IND_PLANO_ASSOCIA ,
            SIT_REGISTRO ,
            OPCAO_CONJUGE
            INTO
            :SUBGVGAP-COD-SUBGRUPO ,
            :SUBGVGAP-COD-CLIENTE ,
            :SUBGVGAP-CLASSE-APOLICE ,
            :SUBGVGAP-COD-FONTE ,
            :SUBGVGAP-TIPO-FATURAMENTO ,
            :SUBGVGAP-FORMA-FATURAMENTO ,
            :SUBGVGAP-FORMA-AVERBACAO ,
            :SUBGVGAP-TIPO-PLANO ,
            :SUBGVGAP-PERI-FATURAMENTO ,
            :SUBGVGAP-PERI-RENOVACAO ,
            :SUBGVGAP-PERI-RETROATI-INC ,
            :SUBGVGAP-PERI-RETROATI-CAN ,
            :SUBGVGAP-OCORR-ENDERECO ,
            :SUBGVGAP-OCORR-END-COBRAN ,
            :SUBGVGAP-BCO-COBRANCA ,
            :SUBGVGAP-AGE-COBRANCA ,
            :SUBGVGAP-DAC-COBRANCA ,
            :SUBGVGAP-TIPO-COBRANCA ,
            :SUBGVGAP-COD-PAG-ANGARIACAO ,
            :SUBGVGAP-PCT-CONJUGE-VG ,
            :SUBGVGAP-PCT-CONJUGE-AP ,
            :SUBGVGAP-OPCAO-COBERTURA ,
            :SUBGVGAP-OPCAO-CORRETAGEM ,
            :SUBGVGAP-IND-CONSISTE-MATRI ,
            :SUBGVGAP-IND-PLANO-ASSOCIA ,
            :SUBGVGAP-SIT-REGISTRO ,
            :SUBGVGAP-OPCAO-CONJUGE
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_SUBGRUPO 
							,
											COD_CLIENTE 
							,
											CLASSE_APOLICE 
							,
											COD_FONTE 
							,
											TIPO_FATURAMENTO 
							,
											FORMA_FATURAMENTO 
							,
											FORMA_AVERBACAO 
							,
											TIPO_PLANO 
							,
											PERI_FATURAMENTO 
							,
											PERI_RENOVACAO 
							,
											PERI_RETROATI_INC 
							,
											PERI_RETROATI_CAN 
							,
											OCORR_ENDERECO 
							,
											OCORR_END_COBRAN 
							,
											BCO_COBRANCA 
							,
											AGE_COBRANCA 
							,
											DAC_COBRANCA 
							,
											TIPO_COBRANCA 
							,
											COD_PAG_ANGARIACAO 
							,
											PCT_CONJUGE_VG 
							,
											PCT_CONJUGE_AP 
							,
											OPCAO_COBERTURA 
							,
											OPCAO_CORRETAGEM 
							,
											IND_CONSISTE_MATRI 
							,
											IND_PLANO_ASSOCIA 
							,
											SIT_REGISTRO 
							,
											OPCAO_CONJUGE
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.SUBGVGAP_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string SUBGVGAP_COD_SUBGRUPO { get; set; }
        public string SUBGVGAP_COD_CLIENTE { get; set; }
        public string SUBGVGAP_CLASSE_APOLICE { get; set; }
        public string SUBGVGAP_COD_FONTE { get; set; }
        public string SUBGVGAP_TIPO_FATURAMENTO { get; set; }
        public string SUBGVGAP_FORMA_FATURAMENTO { get; set; }
        public string SUBGVGAP_FORMA_AVERBACAO { get; set; }
        public string SUBGVGAP_TIPO_PLANO { get; set; }
        public string SUBGVGAP_PERI_FATURAMENTO { get; set; }
        public string SUBGVGAP_PERI_RENOVACAO { get; set; }
        public string SUBGVGAP_PERI_RETROATI_INC { get; set; }
        public string SUBGVGAP_PERI_RETROATI_CAN { get; set; }
        public string SUBGVGAP_OCORR_ENDERECO { get; set; }
        public string SUBGVGAP_OCORR_END_COBRAN { get; set; }
        public string SUBGVGAP_BCO_COBRANCA { get; set; }
        public string SUBGVGAP_AGE_COBRANCA { get; set; }
        public string SUBGVGAP_DAC_COBRANCA { get; set; }
        public string SUBGVGAP_TIPO_COBRANCA { get; set; }
        public string SUBGVGAP_COD_PAG_ANGARIACAO { get; set; }
        public string SUBGVGAP_PCT_CONJUGE_VG { get; set; }
        public string SUBGVGAP_PCT_CONJUGE_AP { get; set; }
        public string SUBGVGAP_OPCAO_COBERTURA { get; set; }
        public string SUBGVGAP_OPCAO_CORRETAGEM { get; set; }
        public string SUBGVGAP_IND_CONSISTE_MATRI { get; set; }
        public string SUBGVGAP_IND_PLANO_ASSOCIA { get; set; }
        public string SUBGVGAP_SIT_REGISTRO { get; set; }
        public string SUBGVGAP_OPCAO_CONJUGE { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 Execute(R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1)
        {
            var ths = r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SUBGVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_CLIENTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_CLASSE_APOLICE = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_FORMA_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_FORMA_AVERBACAO = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_PLANO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_FATURAMENTO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_RETROATI_INC = result[i++].Value?.ToString();
            dta.SUBGVGAP_PERI_RETROATI_CAN = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.SUBGVGAP_OCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.SUBGVGAP_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.SUBGVGAP_COD_PAG_ANGARIACAO = result[i++].Value?.ToString();
            dta.SUBGVGAP_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.SUBGVGAP_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.SUBGVGAP_OPCAO_COBERTURA = result[i++].Value?.ToString();
            dta.SUBGVGAP_OPCAO_CORRETAGEM = result[i++].Value?.ToString();
            dta.SUBGVGAP_IND_CONSISTE_MATRI = result[i++].Value?.ToString();
            dta.SUBGVGAP_IND_PLANO_ASSOCIA = result[i++].Value?.ToString();
            dta.SUBGVGAP_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SUBGVGAP_OPCAO_CONJUGE = result[i++].Value?.ToString();
            return dta;
        }

    }
}