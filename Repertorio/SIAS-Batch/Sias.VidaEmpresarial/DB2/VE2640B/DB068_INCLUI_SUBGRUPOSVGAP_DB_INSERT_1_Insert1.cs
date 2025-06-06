using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1 : QueryBasis<DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SUBGRUPOS_VGAP
            ( NUM_APOLICE ,
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
            OPCAO_CONJUGE ,
            COD_EMPRESA ,
            TIPO_SUBGRUPO ,
            DATA_INCLUSAO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            IND_IOF ,
            TIPO_POSTAGEM )
            VALUES
            ( :SUBGVGAP-NUM-APOLICE ,
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
            :SUBGVGAP-OPCAO-CONJUGE ,
            :SUBGVGAP-COD-EMPRESA ,
            :SUBGVGAP-TIPO-SUBGRUPO ,
            :SUBGVGAP-DATA-INCLUSAO ,
            :SUBGVGAP-DATA-INIVIGENCIA ,
            :SUBGVGAP-DATA-TERVIGENCIA ,
            :SUBGVGAP-IND-IOF ,
            :SUBGVGAP-TIPO-POSTAGEM )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SUBGRUPOS_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE , CLASSE_APOLICE , COD_FONTE , TIPO_FATURAMENTO , FORMA_FATURAMENTO , FORMA_AVERBACAO , TIPO_PLANO , PERI_FATURAMENTO , PERI_RENOVACAO , PERI_RETROATI_INC , PERI_RETROATI_CAN , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , TIPO_COBRANCA , COD_PAG_ANGARIACAO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , OPCAO_COBERTURA , OPCAO_CORRETAGEM , IND_CONSISTE_MATRI , IND_PLANO_ASSOCIA , SIT_REGISTRO , OPCAO_CONJUGE , COD_EMPRESA , TIPO_SUBGRUPO , DATA_INCLUSAO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IND_IOF , TIPO_POSTAGEM ) VALUES ( {FieldThreatment(this.SUBGVGAP_NUM_APOLICE)} , {FieldThreatment(this.SUBGVGAP_COD_SUBGRUPO)} , {FieldThreatment(this.SUBGVGAP_COD_CLIENTE)} , {FieldThreatment(this.SUBGVGAP_CLASSE_APOLICE)} , {FieldThreatment(this.SUBGVGAP_COD_FONTE)} , {FieldThreatment(this.SUBGVGAP_TIPO_FATURAMENTO)} , {FieldThreatment(this.SUBGVGAP_FORMA_FATURAMENTO)} , {FieldThreatment(this.SUBGVGAP_FORMA_AVERBACAO)} , {FieldThreatment(this.SUBGVGAP_TIPO_PLANO)} , {FieldThreatment(this.SUBGVGAP_PERI_FATURAMENTO)} , {FieldThreatment(this.SUBGVGAP_PERI_RENOVACAO)} , {FieldThreatment(this.SUBGVGAP_PERI_RETROATI_INC)} , {FieldThreatment(this.SUBGVGAP_PERI_RETROATI_CAN)} , {FieldThreatment(this.SUBGVGAP_OCORR_ENDERECO)} , {FieldThreatment(this.SUBGVGAP_OCORR_END_COBRAN)} , {FieldThreatment(this.SUBGVGAP_BCO_COBRANCA)} , {FieldThreatment(this.SUBGVGAP_AGE_COBRANCA)} , {FieldThreatment(this.SUBGVGAP_DAC_COBRANCA)} , {FieldThreatment(this.SUBGVGAP_TIPO_COBRANCA)} , {FieldThreatment(this.SUBGVGAP_COD_PAG_ANGARIACAO)} , {FieldThreatment(this.SUBGVGAP_PCT_CONJUGE_VG)} , {FieldThreatment(this.SUBGVGAP_PCT_CONJUGE_AP)} , {FieldThreatment(this.SUBGVGAP_OPCAO_COBERTURA)} , {FieldThreatment(this.SUBGVGAP_OPCAO_CORRETAGEM)} , {FieldThreatment(this.SUBGVGAP_IND_CONSISTE_MATRI)} , {FieldThreatment(this.SUBGVGAP_IND_PLANO_ASSOCIA)} , {FieldThreatment(this.SUBGVGAP_SIT_REGISTRO)} , {FieldThreatment(this.SUBGVGAP_OPCAO_CONJUGE)} , {FieldThreatment(this.SUBGVGAP_COD_EMPRESA)} , {FieldThreatment(this.SUBGVGAP_TIPO_SUBGRUPO)} , {FieldThreatment(this.SUBGVGAP_DATA_INCLUSAO)} , {FieldThreatment(this.SUBGVGAP_DATA_INIVIGENCIA)} , {FieldThreatment(this.SUBGVGAP_DATA_TERVIGENCIA)} , {FieldThreatment(this.SUBGVGAP_IND_IOF)} , {FieldThreatment(this.SUBGVGAP_TIPO_POSTAGEM)} )";

            return query;
        }
        public string SUBGVGAP_NUM_APOLICE { get; set; }
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
        public string SUBGVGAP_COD_EMPRESA { get; set; }
        public string SUBGVGAP_TIPO_SUBGRUPO { get; set; }
        public string SUBGVGAP_DATA_INCLUSAO { get; set; }
        public string SUBGVGAP_DATA_INIVIGENCIA { get; set; }
        public string SUBGVGAP_DATA_TERVIGENCIA { get; set; }
        public string SUBGVGAP_IND_IOF { get; set; }
        public string SUBGVGAP_TIPO_POSTAGEM { get; set; }

        public static void Execute(DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1 dB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1)
        {
            var ths = dB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB068_INCLUI_SUBGRUPOSVGAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}