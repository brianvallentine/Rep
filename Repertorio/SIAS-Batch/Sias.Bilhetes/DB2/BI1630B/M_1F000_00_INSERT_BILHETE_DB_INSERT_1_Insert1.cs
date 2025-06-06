using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1 : QueryBasis<M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.BILHETE
            ( NUM_BILHETE ,
            NUM_APOLICE ,
            FONTE ,
            AGE_COBRANCA ,
            NUM_MATRICULA ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_CLIENTE ,
            PROFISSAO ,
            IDE_SEXO ,
            ESTADO_CIVIL ,
            OCORR_ENDERECO ,
            COD_AGENCIA_DEB ,
            OPERACAO_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            OPC_COBERTURA ,
            DATA_QUITACAO ,
            VAL_RCAP ,
            RAMO ,
            DATA_VENDA ,
            DATA_MOVIMENTO ,
            NUM_APOL_ANTERIOR ,
            SITUACAO ,
            TIP_CANCELAMENTO ,
            SIT_SINISTRO ,
            COD_USUARIO ,
            TIMESTAMP ,
            DATA_CANCELAMENTO ,
            BI_FAIXA_RENDA_IND,
            BI_FAIXA_RENDA_FAM,
            COD_PRODUTO )
            VALUES (:PROPOFID-NUM-SICOB ,
            0 ,
            :BILHETE-FONTE ,
            :PROPOFID-AGECOBR ,
            :PROPOFID-NRMATRVEN ,
            :PROPOFID-AGECTAVEN ,
            :PROPOFID-OPRCTAVEN ,
            :PROPOFID-NUMCTAVEN ,
            :PROPOFID-DIGCTAVEN ,
            :WS-COD-CLI-ATU ,
            :BILHETE-PROFISSAO ,
            :BI0005L-S-SEXO ,
            :BI0005L-S-ESTADO-CIVIL ,
            :WS-OCC-END-ATU ,
            :PROPOFID-AGECTADEB ,
            :PROPOFID-OPRCTADEB ,
            :PROPOFID-NUMCTADEB ,
            :PROPOFID-DIGCTADEB ,
            :BILHETE-OPC-COBERTURA ,
            :PROPOFID-DTQITBCO ,
            :PROPOFID-VAL-PAGO ,
            :BILHETE-RAMO ,
            :PROPOFID-DTQITBCO ,
            :WS-DATA-PROC ,
            :BILHETE-NUM-APOL-ANTERIOR ,
            :WS-SIT-BIL ,
            '0' ,
            '0' ,
            'BI1630B' ,
            CURRENT TIMESTAMP ,
            NULL ,
            :BILHETE-BI-FAIXA-RENDA-IND ,
            :BILHETE-BI-FAIXA-RENDA-FAM ,
            :PRDSIVPF-COD-PRODUTO )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BILHETE ( NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND, BI_FAIXA_RENDA_FAM, COD_PRODUTO ) VALUES ({FieldThreatment(this.PROPOFID_NUM_SICOB)} , 0 , {FieldThreatment(this.BILHETE_FONTE)} , {FieldThreatment(this.PROPOFID_AGECOBR)} , {FieldThreatment(this.PROPOFID_NRMATRVEN)} , {FieldThreatment(this.PROPOFID_AGECTAVEN)} , {FieldThreatment(this.PROPOFID_OPRCTAVEN)} , {FieldThreatment(this.PROPOFID_NUMCTAVEN)} , {FieldThreatment(this.PROPOFID_DIGCTAVEN)} , {FieldThreatment(this.WS_COD_CLI_ATU)} , {FieldThreatment(this.BILHETE_PROFISSAO)} , {FieldThreatment(this.BI0005L_S_SEXO)} , {FieldThreatment(this.BI0005L_S_ESTADO_CIVIL)} , {FieldThreatment(this.WS_OCC_END_ATU)} , {FieldThreatment(this.PROPOFID_AGECTADEB)} , {FieldThreatment(this.PROPOFID_OPRCTADEB)} , {FieldThreatment(this.PROPOFID_NUMCTADEB)} , {FieldThreatment(this.PROPOFID_DIGCTADEB)} , {FieldThreatment(this.BILHETE_OPC_COBERTURA)} , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.PROPOFID_VAL_PAGO)} , {FieldThreatment(this.BILHETE_RAMO)} , {FieldThreatment(this.PROPOFID_DTQITBCO)} , {FieldThreatment(this.WS_DATA_PROC)} , {FieldThreatment(this.BILHETE_NUM_APOL_ANTERIOR)} , {FieldThreatment(this.WS_SIT_BIL)} , '0' , '0' , 'BI1630B' , CURRENT TIMESTAMP , NULL , {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_IND)} , {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_FAM)} , {FieldThreatment(this.PRDSIVPF_COD_PRODUTO)} )";

            return query;
        }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string BILHETE_FONTE { get; set; }
        public string PROPOFID_AGECOBR { get; set; }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string PROPOFID_AGECTAVEN { get; set; }
        public string PROPOFID_OPRCTAVEN { get; set; }
        public string PROPOFID_NUMCTAVEN { get; set; }
        public string PROPOFID_DIGCTAVEN { get; set; }
        public string WS_COD_CLI_ATU { get; set; }
        public string BILHETE_PROFISSAO { get; set; }
        public string BI0005L_S_SEXO { get; set; }
        public string BI0005L_S_ESTADO_CIVIL { get; set; }
        public string WS_OCC_END_ATU { get; set; }
        public string PROPOFID_AGECTADEB { get; set; }
        public string PROPOFID_OPRCTADEB { get; set; }
        public string PROPOFID_NUMCTADEB { get; set; }
        public string PROPOFID_DIGCTADEB { get; set; }
        public string BILHETE_OPC_COBERTURA { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string BILHETE_RAMO { get; set; }
        public string WS_DATA_PROC { get; set; }
        public string BILHETE_NUM_APOL_ANTERIOR { get; set; }
        public string WS_SIT_BIL { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_IND { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_FAM { get; set; }
        public string PRDSIVPF_COD_PRODUTO { get; set; }

        public static void Execute(M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1 m_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1)
        {
            var ths = m_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}