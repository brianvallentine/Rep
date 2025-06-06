using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0035B
{
    public class R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            NUM_APOLICE,
            COD_SUBGRUPO,
            COD_FONTE,
            NUM_PROPOSTA,
            TIPO_SEGURADO,
            NUM_CERTIFICADO,
            DAC_CERTIFICADO,
            TIPO_INCLUSAO,
            COD_CLIENTE,
            COD_AGENCIADOR,
            COD_CORRETOR,
            COD_PLANOVGAP,
            COD_PLANOAP,
            FAIXA,
            AUTOR_AUM_AUTOMAT,
            TIPO_BENEFICIARIO,
            PERI_PAGAMENTO,
            PERI_RENOVACAO,
            COD_OCUPACAO,
            ESTADO_CIVIL,
            IDE_SEXO,
            COD_PROFISSAO,
            NATURALIDADE,
            OCORR_ENDERECO,
            OCORR_END_COBRAN,
            BCO_COBRANCA,
            AGE_COBRANCA,
            DAC_COBRANCA,
            NUM_MATRICULA,
            NUM_CTA_CORRENTE,
            DAC_CTA_CORRENTE,
            VAL_SALARIO,
            TIPO_SALARIO,
            TIPO_PLANO,
            PCT_CONJUGE_VG,
            PCT_CONJUGE_AP,
            QTD_SAL_MORNATU,
            QTD_SAL_MORACID,
            QTD_SAL_INVPERM,
            TAXA_AP_MORACID,
            TAXA_AP_INVPERM,
            TAXA_AP_AMDS,
            TAXA_AP_DH,
            TAXA_AP_DIT,
            TAXA_VG,
            IMP_MORNATU_ANT,
            IMP_MORNATU_ATU,
            IMP_MORACID_ANT,
            IMP_MORACID_ATU,
            IMP_INVPERM_ANT,
            IMP_INVPERM_ATU,
            IMP_AMDS_ANT,
            IMP_AMDS_ATU,
            IMP_DH_ANT,
            IMP_DH_ATU,
            IMP_DIT_ANT,
            IMP_DIT_ATU,
            PRM_VG_ANT,
            PRM_VG_ATU,
            PRM_AP_ANT,
            PRM_AP_ATU,
            COD_OPERACAO,
            DATA_OPERACAO,
            COD_SUBGRUPO_TRANS,
            SIT_REGISTRO,
            COD_USUARIO,
            DATA_AVERBACAO,
            DATA_ADMISSAO,
            DATA_INCLUSAO,
            DATA_NASCIMENTO,
            DATA_FATURA,
            DATA_REFERENCIA,
            DATA_MOVIMENTO,
            COD_EMPRESA,
            LOT_EMP_SEGURADO
            INTO
            :MOVIMVGA-NUM-APOLICE ,
            :MOVIMVGA-COD-SUBGRUPO ,
            :MOVIMVGA-COD-FONTE ,
            :MOVIMVGA-NUM-PROPOSTA ,
            :MOVIMVGA-TIPO-SEGURADO ,
            :MOVIMVGA-NUM-CERTIFICADO ,
            :MOVIMVGA-DAC-CERTIFICADO ,
            :MOVIMVGA-TIPO-INCLUSAO ,
            :MOVIMVGA-COD-CLIENTE ,
            :MOVIMVGA-COD-AGENCIADOR ,
            :MOVIMVGA-COD-CORRETOR ,
            :MOVIMVGA-COD-PLANOVGAP ,
            :MOVIMVGA-COD-PLANOAP ,
            :MOVIMVGA-FAIXA ,
            :MOVIMVGA-AUTOR-AUM-AUTOMAT,
            :MOVIMVGA-TIPO-BENEFICIARIO,
            :MOVIMVGA-PERI-PAGAMENTO ,
            :MOVIMVGA-PERI-RENOVACAO ,
            :MOVIMVGA-COD-OCUPACAO ,
            :MOVIMVGA-ESTADO-CIVIL ,
            :MOVIMVGA-IDE-SEXO ,
            :MOVIMVGA-COD-PROFISSAO ,
            :MOVIMVGA-NATURALIDADE ,
            :MOVIMVGA-OCORR-ENDERECO ,
            :MOVIMVGA-OCORR-END-COBRAN ,
            :MOVIMVGA-BCO-COBRANCA ,
            :MOVIMVGA-AGE-COBRANCA ,
            :MOVIMVGA-DAC-COBRANCA ,
            :MOVIMVGA-NUM-MATRICULA ,
            :MOVIMVGA-NUM-CTA-CORRENTE ,
            :MOVIMVGA-DAC-CTA-CORRENTE ,
            :MOVIMVGA-VAL-SALARIO ,
            :MOVIMVGA-TIPO-SALARIO ,
            :MOVIMVGA-TIPO-PLANO ,
            :MOVIMVGA-PCT-CONJUGE-VG ,
            :MOVIMVGA-PCT-CONJUGE-AP ,
            :MOVIMVGA-QTD-SAL-MORNATU ,
            :MOVIMVGA-QTD-SAL-MORACID ,
            :MOVIMVGA-QTD-SAL-INVPERM ,
            :MOVIMVGA-TAXA-AP-MORACID ,
            :MOVIMVGA-TAXA-AP-INVPERM ,
            :MOVIMVGA-TAXA-AP-AMDS ,
            :MOVIMVGA-TAXA-AP-DH ,
            :MOVIMVGA-TAXA-AP-DIT ,
            :MOVIMVGA-TAXA-VG ,
            :MOVIMVGA-IMP-MORNATU-ANT ,
            :MOVIMVGA-IMP-MORNATU-ATU ,
            :MOVIMVGA-IMP-MORACID-ANT ,
            :MOVIMVGA-IMP-MORACID-ATU ,
            :MOVIMVGA-IMP-INVPERM-ANT ,
            :MOVIMVGA-IMP-INVPERM-ATU ,
            :MOVIMVGA-IMP-AMDS-ANT ,
            :MOVIMVGA-IMP-AMDS-ATU ,
            :MOVIMVGA-IMP-DH-ANT ,
            :MOVIMVGA-IMP-DH-ATU ,
            :MOVIMVGA-IMP-DIT-ANT ,
            :MOVIMVGA-IMP-DIT-ATU ,
            :MOVIMVGA-PRM-VG-ANT ,
            :MOVIMVGA-PRM-VG-ATU ,
            :MOVIMVGA-PRM-AP-ANT ,
            :MOVIMVGA-PRM-AP-ATU ,
            :MOVIMVGA-COD-OPERACAO ,
            :MOVIMVGA-DATA-OPERACAO ,
            :MOVIMVGA-COD-SUBGRUPO-TRANS,
            :MOVIMVGA-SIT-REGISTRO ,
            :MOVIMVGA-COD-USUARIO ,
            :MOVIMVGA-DATA-AVERBACAO :VIND-DATA-AVERBACAO,
            :MOVIMVGA-DATA-ADMISSAO :VIND-DATA-ADMISSAO,
            :MOVIMVGA-DATA-INCLUSAO :VIND-DATA-INCLUSAO,
            :MOVIMVGA-DATA-NASCIMENTO :VIND-DATA-NASCIMENTO,
            :MOVIMVGA-DATA-FATURA :VIND-DATA-FATURA,
            :MOVIMVGA-DATA-REFERENCIA :VIND-DATA-REFERENCIA,
            :MOVIMVGA-DATA-MOVIMENTO :VIND-DATA-MOVIMENTO,
            :MOVIMVGA-COD-EMPRESA :VIND-COD-EMPRESA,
            :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURA
            FROM
            SEGUROS.MOVIMENTO_VGAP
            WHERE
            NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_INCLUSAO IS NULL
            ORDER BY DATA_INCLUSAO DESC
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NUM_APOLICE
							,
											COD_SUBGRUPO
							,
											COD_FONTE
							,
											NUM_PROPOSTA
							,
											TIPO_SEGURADO
							,
											NUM_CERTIFICADO
							,
											DAC_CERTIFICADO
							,
											TIPO_INCLUSAO
							,
											COD_CLIENTE
							,
											COD_AGENCIADOR
							,
											COD_CORRETOR
							,
											COD_PLANOVGAP
							,
											COD_PLANOAP
							,
											FAIXA
							,
											AUTOR_AUM_AUTOMAT
							,
											TIPO_BENEFICIARIO
							,
											PERI_PAGAMENTO
							,
											PERI_RENOVACAO
							,
											COD_OCUPACAO
							,
											ESTADO_CIVIL
							,
											IDE_SEXO
							,
											COD_PROFISSAO
							,
											NATURALIDADE
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
											NUM_MATRICULA
							,
											NUM_CTA_CORRENTE
							,
											DAC_CTA_CORRENTE
							,
											VAL_SALARIO
							,
											TIPO_SALARIO
							,
											TIPO_PLANO
							,
											PCT_CONJUGE_VG
							,
											PCT_CONJUGE_AP
							,
											QTD_SAL_MORNATU
							,
											QTD_SAL_MORACID
							,
											QTD_SAL_INVPERM
							,
											TAXA_AP_MORACID
							,
											TAXA_AP_INVPERM
							,
											TAXA_AP_AMDS
							,
											TAXA_AP_DH
							,
											TAXA_AP_DIT
							,
											TAXA_VG
							,
											IMP_MORNATU_ANT
							,
											IMP_MORNATU_ATU
							,
											IMP_MORACID_ANT
							,
											IMP_MORACID_ATU
							,
											IMP_INVPERM_ANT
							,
											IMP_INVPERM_ATU
							,
											IMP_AMDS_ANT
							,
											IMP_AMDS_ATU
							,
											IMP_DH_ANT
							,
											IMP_DH_ATU
							,
											IMP_DIT_ANT
							,
											IMP_DIT_ATU
							,
											PRM_VG_ANT
							,
											PRM_VG_ATU
							,
											PRM_AP_ANT
							,
											PRM_AP_ATU
							,
											COD_OPERACAO
							,
											DATA_OPERACAO
							,
											COD_SUBGRUPO_TRANS
							,
											SIT_REGISTRO
							,
											COD_USUARIO
							,
											DATA_AVERBACAO
							,
											DATA_ADMISSAO
							,
											DATA_INCLUSAO
							,
											DATA_NASCIMENTO
							,
											DATA_FATURA
							,
											DATA_REFERENCIA
							,
											DATA_MOVIMENTO
							,
											COD_EMPRESA
							,
											LOT_EMP_SEGURADO
											FROM
											SEGUROS.MOVIMENTO_VGAP
											WHERE
											NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_INCLUSAO IS NULL
											ORDER BY DATA_INCLUSAO DESC
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string MOVIMVGA_NUM_APOLICE { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO { get; set; }
        public string MOVIMVGA_COD_FONTE { get; set; }
        public string MOVIMVGA_NUM_PROPOSTA { get; set; }
        public string MOVIMVGA_TIPO_SEGURADO { get; set; }
        public string MOVIMVGA_NUM_CERTIFICADO { get; set; }
        public string MOVIMVGA_DAC_CERTIFICADO { get; set; }
        public string MOVIMVGA_TIPO_INCLUSAO { get; set; }
        public string MOVIMVGA_COD_CLIENTE { get; set; }
        public string MOVIMVGA_COD_AGENCIADOR { get; set; }
        public string MOVIMVGA_COD_CORRETOR { get; set; }
        public string MOVIMVGA_COD_PLANOVGAP { get; set; }
        public string MOVIMVGA_COD_PLANOAP { get; set; }
        public string MOVIMVGA_FAIXA { get; set; }
        public string MOVIMVGA_AUTOR_AUM_AUTOMAT { get; set; }
        public string MOVIMVGA_TIPO_BENEFICIARIO { get; set; }
        public string MOVIMVGA_PERI_PAGAMENTO { get; set; }
        public string MOVIMVGA_PERI_RENOVACAO { get; set; }
        public string MOVIMVGA_COD_OCUPACAO { get; set; }
        public string MOVIMVGA_ESTADO_CIVIL { get; set; }
        public string MOVIMVGA_IDE_SEXO { get; set; }
        public string MOVIMVGA_COD_PROFISSAO { get; set; }
        public string MOVIMVGA_NATURALIDADE { get; set; }
        public string MOVIMVGA_OCORR_ENDERECO { get; set; }
        public string MOVIMVGA_OCORR_END_COBRAN { get; set; }
        public string MOVIMVGA_BCO_COBRANCA { get; set; }
        public string MOVIMVGA_AGE_COBRANCA { get; set; }
        public string MOVIMVGA_DAC_COBRANCA { get; set; }
        public string MOVIMVGA_NUM_MATRICULA { get; set; }
        public string MOVIMVGA_NUM_CTA_CORRENTE { get; set; }
        public string MOVIMVGA_DAC_CTA_CORRENTE { get; set; }
        public string MOVIMVGA_VAL_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_SALARIO { get; set; }
        public string MOVIMVGA_TIPO_PLANO { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_VG { get; set; }
        public string MOVIMVGA_PCT_CONJUGE_AP { get; set; }
        public string MOVIMVGA_QTD_SAL_MORNATU { get; set; }
        public string MOVIMVGA_QTD_SAL_MORACID { get; set; }
        public string MOVIMVGA_QTD_SAL_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_MORACID { get; set; }
        public string MOVIMVGA_TAXA_AP_INVPERM { get; set; }
        public string MOVIMVGA_TAXA_AP_AMDS { get; set; }
        public string MOVIMVGA_TAXA_AP_DH { get; set; }
        public string MOVIMVGA_TAXA_AP_DIT { get; set; }
        public string MOVIMVGA_TAXA_VG { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ANT { get; set; }
        public string MOVIMVGA_IMP_MORNATU_ATU { get; set; }
        public string MOVIMVGA_IMP_MORACID_ANT { get; set; }
        public string MOVIMVGA_IMP_MORACID_ATU { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ANT { get; set; }
        public string MOVIMVGA_IMP_INVPERM_ATU { get; set; }
        public string MOVIMVGA_IMP_AMDS_ANT { get; set; }
        public string MOVIMVGA_IMP_AMDS_ATU { get; set; }
        public string MOVIMVGA_IMP_DH_ANT { get; set; }
        public string MOVIMVGA_IMP_DH_ATU { get; set; }
        public string MOVIMVGA_IMP_DIT_ANT { get; set; }
        public string MOVIMVGA_IMP_DIT_ATU { get; set; }
        public string MOVIMVGA_PRM_VG_ANT { get; set; }
        public string MOVIMVGA_PRM_VG_ATU { get; set; }
        public string MOVIMVGA_PRM_AP_ANT { get; set; }
        public string MOVIMVGA_PRM_AP_ATU { get; set; }
        public string MOVIMVGA_COD_OPERACAO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }
        public string MOVIMVGA_COD_SUBGRUPO_TRANS { get; set; }
        public string MOVIMVGA_SIT_REGISTRO { get; set; }
        public string MOVIMVGA_COD_USUARIO { get; set; }
        public string MOVIMVGA_DATA_AVERBACAO { get; set; }
        public string VIND_DATA_AVERBACAO { get; set; }
        public string MOVIMVGA_DATA_ADMISSAO { get; set; }
        public string VIND_DATA_ADMISSAO { get; set; }
        public string MOVIMVGA_DATA_INCLUSAO { get; set; }
        public string VIND_DATA_INCLUSAO { get; set; }
        public string MOVIMVGA_DATA_NASCIMENTO { get; set; }
        public string VIND_DATA_NASCIMENTO { get; set; }
        public string MOVIMVGA_DATA_FATURA { get; set; }
        public string VIND_DATA_FATURA { get; set; }
        public string MOVIMVGA_DATA_REFERENCIA { get; set; }
        public string VIND_DATA_REFERENCIA { get; set; }
        public string MOVIMVGA_DATA_MOVIMENTO { get; set; }
        public string VIND_DATA_MOVIMENTO { get; set; }
        public string MOVIMVGA_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }
        public string MOVIMVGA_LOT_EMP_SEGURADO { get; set; }
        public string VIND_LOT_EMP_SEGURA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 r1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVIMVGA_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_FONTE = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_INCLUSAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_CLIENTE = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_AGENCIADOR = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_CORRETOR = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_PLANOVGAP = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_PLANOAP = result[i++].Value?.ToString();
            dta.MOVIMVGA_FAIXA = result[i++].Value?.ToString();
            dta.MOVIMVGA_AUTOR_AUM_AUTOMAT = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_BENEFICIARIO = result[i++].Value?.ToString();
            dta.MOVIMVGA_PERI_PAGAMENTO = result[i++].Value?.ToString();
            dta.MOVIMVGA_PERI_RENOVACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OCUPACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.MOVIMVGA_IDE_SEXO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_PROFISSAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_NATURALIDADE = result[i++].Value?.ToString();
            dta.MOVIMVGA_OCORR_ENDERECO = result[i++].Value?.ToString();
            dta.MOVIMVGA_OCORR_END_COBRAN = result[i++].Value?.ToString();
            dta.MOVIMVGA_BCO_COBRANCA = result[i++].Value?.ToString();
            dta.MOVIMVGA_AGE_COBRANCA = result[i++].Value?.ToString();
            dta.MOVIMVGA_DAC_COBRANCA = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_MATRICULA = result[i++].Value?.ToString();
            dta.MOVIMVGA_NUM_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MOVIMVGA_DAC_CTA_CORRENTE = result[i++].Value?.ToString();
            dta.MOVIMVGA_VAL_SALARIO = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_SALARIO = result[i++].Value?.ToString();
            dta.MOVIMVGA_TIPO_PLANO = result[i++].Value?.ToString();
            dta.MOVIMVGA_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.MOVIMVGA_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.MOVIMVGA_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.MOVIMVGA_TAXA_VG = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORACID_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_INVPERM_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_INVPERM_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_AMDS_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_AMDS_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DH_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DH_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DIT_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_IMP_DIT_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_VG_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_VG_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_AP_ANT = result[i++].Value?.ToString();
            dta.MOVIMVGA_PRM_AP_ATU = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_OPERACAO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_SUBGRUPO_TRANS = result[i++].Value?.ToString();
            dta.MOVIMVGA_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVIMVGA_COD_USUARIO = result[i++].Value?.ToString();
            dta.MOVIMVGA_DATA_AVERBACAO = result[i++].Value?.ToString();
            dta.VIND_DATA_AVERBACAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_AVERBACAO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_ADMISSAO = result[i++].Value?.ToString();
            dta.VIND_DATA_ADMISSAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_ADMISSAO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_INCLUSAO = result[i++].Value?.ToString();
            dta.VIND_DATA_INCLUSAO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_INCLUSAO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.VIND_DATA_NASCIMENTO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_NASCIMENTO) ? "-1" : "0";
            dta.MOVIMVGA_DATA_FATURA = result[i++].Value?.ToString();
            dta.VIND_DATA_FATURA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_FATURA) ? "-1" : "0";
            dta.MOVIMVGA_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.VIND_DATA_REFERENCIA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_REFERENCIA) ? "-1" : "0";
            dta.MOVIMVGA_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.VIND_DATA_MOVIMENTO = string.IsNullOrWhiteSpace(dta.MOVIMVGA_DATA_MOVIMENTO) ? "-1" : "0";
            dta.MOVIMVGA_COD_EMPRESA = result[i++].Value?.ToString();
            dta.VIND_COD_EMPRESA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_COD_EMPRESA) ? "-1" : "0";
            dta.MOVIMVGA_LOT_EMP_SEGURADO = result[i++].Value?.ToString();
            dta.VIND_LOT_EMP_SEGURA = string.IsNullOrWhiteSpace(dta.MOVIMVGA_LOT_EMP_SEGURADO) ? "-1" : "0";
            return dta;
        }

    }
}