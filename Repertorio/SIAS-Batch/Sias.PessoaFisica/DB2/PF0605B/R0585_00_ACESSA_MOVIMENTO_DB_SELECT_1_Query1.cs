using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 : QueryBasis<R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_FONTE ,
            NUM_PROPOSTA ,
            TIPO_SEGURADO ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            IDE_SEXO ,
            PCT_CONJUGE_VG ,
            PCT_CONJUGE_AP ,
            QTD_SAL_MORNATU ,
            QTD_SAL_MORACID ,
            QTD_SAL_INVPERM ,
            TAXA_AP_MORACID ,
            TAXA_AP_INVPERM ,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT ,
            TAXA_VG ,
            IMP_MORNATU_ANT ,
            IMP_MORNATU_ATU ,
            IMP_MORACID_ANT ,
            IMP_MORACID_ATU ,
            IMP_INVPERM_ANT ,
            IMP_INVPERM_ATU ,
            IMP_AMDS_ANT ,
            IMP_AMDS_ATU ,
            IMP_DH_ANT ,
            IMP_DH_ATU ,
            IMP_DIT_ANT ,
            IMP_DIT_ATU ,
            PRM_VG_ANT ,
            PRM_VG_ATU ,
            PRM_AP_ANT ,
            PRM_AP_ATU ,
            COD_OPERACAO ,
            DATA_OPERACAO ,
            DATA_REFERENCIA ,
            DATA_MOVIMENTO ,
            COD_SUBGRUPO_TRANS ,
            SIT_REGISTRO ,
            COD_USUARIO
            INTO :MOVVGAP-NUM-APOLICE ,
            :MOVVGAP-COD-SUBGRUPO ,
            :MOVVGAP-COD-FONTE ,
            :MOVVGAP-NUM-PROPOSTA ,
            :MOVVGAP-TIPO-SEGURADO ,
            :MOVVGAP-NUM-CERTIFICADO ,
            :MOVVGAP-DAC-CERTIFICADO ,
            :MOVVGAP-IDE-SEXO ,
            :MOVVGAP-PCT-CONJUGE-VG ,
            :MOVVGAP-PCT-CONJUGE-AP ,
            :MOVVGAP-QTD-SAL-MORNATU ,
            :MOVVGAP-QTD-SAL-MORACID ,
            :MOVVGAP-QTD-SAL-INVPERM ,
            :MOVVGAP-TAXA-AP-MORACID ,
            :MOVVGAP-TAXA-AP-INVPERM ,
            :MOVVGAP-TAXA-AP-AMDS ,
            :MOVVGAP-TAXA-AP-DH ,
            :MOVVGAP-TAXA-AP-DIT ,
            :MOVVGAP-TAXA-VG ,
            :MOVVGAP-IMP-MORNATU-ANT ,
            :MOVVGAP-IMP-MORNATU-ATU ,
            :MOVVGAP-IMP-MORACID-ANT ,
            :MOVVGAP-IMP-MORACID-ATU ,
            :MOVVGAP-IMP-INVPERM-ANT ,
            :MOVVGAP-IMP-INVPERM-ATU ,
            :MOVVGAP-IMP-AMDS-ANT ,
            :MOVVGAP-IMP-AMDS-ATU ,
            :MOVVGAP-IMP-DH-ANT ,
            :MOVVGAP-IMP-DH-ATU ,
            :MOVVGAP-IMP-DIT-ANT ,
            :MOVVGAP-IMP-DIT-ATU ,
            :MOVVGAP-PRM-VG-ANT ,
            :MOVVGAP-PRM-VG-ATU ,
            :MOVVGAP-PRM-AP-ANT ,
            :MOVVGAP-PRM-AP-ATU ,
            :MOVVGAP-COD-OPERACAO ,
            :MOVVGAP-DATA-OPERACAO ,
            :MOVVGAP-DATA-REFERENCIA ,
            :MOVVGAP-DATA-MOVIMENTO ,
            :MOVVGAP-COD-SUBGRUPO-TRANS ,
            :MOVVGAP-SIT-REGISTRO ,
            :MOVVGAP-COD-USUARIO
            FROM SEGUROS.MOVIMENTO_VGAP
            WHERE NUM_APOLICE = :MOVVGAP-NUM-APOLICE
            AND COD_SUBGRUPO = :MOVVGAP-COD-SUBGRUPO
            AND NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO
            AND COD_OPERACAO BETWEEN 100 AND 199
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
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
											IDE_SEXO 
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
											DATA_REFERENCIA 
							,
											DATA_MOVIMENTO 
							,
											COD_SUBGRUPO_TRANS 
							,
											SIT_REGISTRO 
							,
											COD_USUARIO
											FROM SEGUROS.MOVIMENTO_VGAP
											WHERE NUM_APOLICE = '{this.MOVVGAP_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.MOVVGAP_COD_SUBGRUPO}'
											AND NUM_CERTIFICADO = '{this.MOVVGAP_NUM_CERTIFICADO}'
											AND COD_OPERACAO BETWEEN 100 AND 199
											WITH UR";

            return query;
        }
        public string MOVVGAP_NUM_APOLICE { get; set; }
        public string MOVVGAP_COD_SUBGRUPO { get; set; }
        public string MOVVGAP_COD_FONTE { get; set; }
        public string MOVVGAP_NUM_PROPOSTA { get; set; }
        public string MOVVGAP_TIPO_SEGURADO { get; set; }
        public string MOVVGAP_NUM_CERTIFICADO { get; set; }
        public string MOVVGAP_DAC_CERTIFICADO { get; set; }
        public string MOVVGAP_IDE_SEXO { get; set; }
        public string MOVVGAP_PCT_CONJUGE_VG { get; set; }
        public string MOVVGAP_PCT_CONJUGE_AP { get; set; }
        public string MOVVGAP_QTD_SAL_MORNATU { get; set; }
        public string MOVVGAP_QTD_SAL_MORACID { get; set; }
        public string MOVVGAP_QTD_SAL_INVPERM { get; set; }
        public string MOVVGAP_TAXA_AP_MORACID { get; set; }
        public string MOVVGAP_TAXA_AP_INVPERM { get; set; }
        public string MOVVGAP_TAXA_AP_AMDS { get; set; }
        public string MOVVGAP_TAXA_AP_DH { get; set; }
        public string MOVVGAP_TAXA_AP_DIT { get; set; }
        public string MOVVGAP_TAXA_VG { get; set; }
        public string MOVVGAP_IMP_MORNATU_ANT { get; set; }
        public string MOVVGAP_IMP_MORNATU_ATU { get; set; }
        public string MOVVGAP_IMP_MORACID_ANT { get; set; }
        public string MOVVGAP_IMP_MORACID_ATU { get; set; }
        public string MOVVGAP_IMP_INVPERM_ANT { get; set; }
        public string MOVVGAP_IMP_INVPERM_ATU { get; set; }
        public string MOVVGAP_IMP_AMDS_ANT { get; set; }
        public string MOVVGAP_IMP_AMDS_ATU { get; set; }
        public string MOVVGAP_IMP_DH_ANT { get; set; }
        public string MOVVGAP_IMP_DH_ATU { get; set; }
        public string MOVVGAP_IMP_DIT_ANT { get; set; }
        public string MOVVGAP_IMP_DIT_ATU { get; set; }
        public string MOVVGAP_PRM_VG_ANT { get; set; }
        public string MOVVGAP_PRM_VG_ATU { get; set; }
        public string MOVVGAP_PRM_AP_ANT { get; set; }
        public string MOVVGAP_PRM_AP_ATU { get; set; }
        public string MOVVGAP_COD_OPERACAO { get; set; }
        public string MOVVGAP_DATA_OPERACAO { get; set; }
        public string MOVVGAP_DATA_REFERENCIA { get; set; }
        public string MOVVGAP_DATA_MOVIMENTO { get; set; }
        public string MOVVGAP_COD_SUBGRUPO_TRANS { get; set; }
        public string MOVVGAP_SIT_REGISTRO { get; set; }
        public string MOVVGAP_COD_USUARIO { get; set; }

        public static R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 Execute(R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 r0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1)
        {
            var ths = r0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.MOVVGAP_NUM_APOLICE = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_SUBGRUPO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_FONTE = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_PROPOSTA = result[i++].Value?.ToString();
            dta.MOVVGAP_TIPO_SEGURADO = result[i++].Value?.ToString();
            dta.MOVVGAP_NUM_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVVGAP_DAC_CERTIFICADO = result[i++].Value?.ToString();
            dta.MOVVGAP_IDE_SEXO = result[i++].Value?.ToString();
            dta.MOVVGAP_PCT_CONJUGE_VG = result[i++].Value?.ToString();
            dta.MOVVGAP_PCT_CONJUGE_AP = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_MORNATU = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_MORACID = result[i++].Value?.ToString();
            dta.MOVVGAP_QTD_SAL_INVPERM = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_MORACID = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_INVPERM = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_AMDS = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_DH = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_AP_DIT = result[i++].Value?.ToString();
            dta.MOVVGAP_TAXA_VG = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORNATU_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORNATU_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORACID_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_MORACID_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_INVPERM_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_INVPERM_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_AMDS_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_AMDS_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DH_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DH_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DIT_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_IMP_DIT_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_VG_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_VG_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_AP_ANT = result[i++].Value?.ToString();
            dta.MOVVGAP_PRM_AP_ATU = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_OPERACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_DATA_OPERACAO = result[i++].Value?.ToString();
            dta.MOVVGAP_DATA_REFERENCIA = result[i++].Value?.ToString();
            dta.MOVVGAP_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_SUBGRUPO_TRANS = result[i++].Value?.ToString();
            dta.MOVVGAP_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.MOVVGAP_COD_USUARIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}