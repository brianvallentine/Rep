using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R3000_10_CONTINUA_DB_INSERT_1_Insert1 : QueryBasis<R3000_10_CONTINUA_DB_INSERT_1_Insert1>
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
            COD_PRODUTO
            )
            VALUES (
            :DCLPROPOSTA-FIDELIZ.NUM-SICOB ,
            0,
            :WHOST-FONTE,
            :DCLPROPOSTA-FIDELIZ.AGECOBR ,
            :DCLPROPOSTA-FIDELIZ.NRMATRVEN ,
            :DCLPROPOSTA-FIDELIZ.AGECTAVEN ,
            :DCLPROPOSTA-FIDELIZ.OPRCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.NUMCTAVEN ,
            :DCLPROPOSTA-FIDELIZ.DIGCTAVEN ,
            :DCLCLIENTES.COD-CLIENTE ,
            :WHOST-PROFISSAO ,
            :DCLPESSOA-FISICA.SEXO ,
            :DCLPESSOA-FISICA.ESTADO-CIVIL ,
            1,
            :DCLPROPOSTA-FIDELIZ.AGECTADEB ,
            :DCLPROPOSTA-FIDELIZ.OPRCTADEB ,
            :DCLPROPOSTA-FIDELIZ.NUMCTADEB ,
            :DCLPROPOSTA-FIDELIZ.DIGCTADEB ,
            :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO,
            :DCLPROPOSTA-FIDELIZ.DTQITBCO ,
            :DCLPROPOSTA-FIDELIZ.VAL-PAGO ,
            :WHOST-RAMO ,
            :DCLPROPOSTA-FIDELIZ.DTQITBCO ,
            :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO ,
            0,
            :WHOST-SIT-REGISTRO ,
            '0' ,
            '0' ,
            'PF0602B' ,
            CURRENT TIMESTAMP,
            NULL,
            :BILHETE-BI-FAIXA-RENDA-IND,
            :BILHETE-BI-FAIXA-RENDA-FAM,
            :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.BILHETE ( NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND, BI_FAIXA_RENDA_FAM, COD_PRODUTO ) VALUES ( {FieldThreatment(this.NUM_SICOB)} , 0, {FieldThreatment(this.WHOST_FONTE)}, {FieldThreatment(this.AGECOBR)} , {FieldThreatment(this.NRMATRVEN)} , {FieldThreatment(this.AGECTAVEN)} , {FieldThreatment(this.OPRCTAVEN)} , {FieldThreatment(this.NUMCTAVEN)} , {FieldThreatment(this.DIGCTAVEN)} , {FieldThreatment(this.COD_CLIENTE)} , {FieldThreatment(this.WHOST_PROFISSAO)} , {FieldThreatment(this.SEXO)} , {FieldThreatment(this.ESTADO_CIVIL)} , 1, {FieldThreatment(this.AGECTADEB)} , {FieldThreatment(this.OPRCTADEB)} , {FieldThreatment(this.NUMCTADEB)} , {FieldThreatment(this.DIGCTADEB)} , {FieldThreatment(this.BILHECOB_COD_OPCAO_PLANO)}, {FieldThreatment(this.DTQITBCO)} , {FieldThreatment(this.VAL_PAGO)} , {FieldThreatment(this.WHOST_RAMO)} , {FieldThreatment(this.DTQITBCO)} , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)} , 0, {FieldThreatment(this.WHOST_SIT_REGISTRO)} , '0' , '0' , 'PF0602B' , CURRENT TIMESTAMP, NULL, {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_IND)}, {FieldThreatment(this.BILHETE_BI_FAIXA_RENDA_FAM)}, {FieldThreatment(this.BILHECOB_COD_PRODUTO)} )";

            return query;
        }
        public string NUM_SICOB { get; set; }
        public string WHOST_FONTE { get; set; }
        public string AGECOBR { get; set; }
        public string NRMATRVEN { get; set; }
        public string AGECTAVEN { get; set; }
        public string OPRCTAVEN { get; set; }
        public string NUMCTAVEN { get; set; }
        public string DIGCTAVEN { get; set; }
        public string COD_CLIENTE { get; set; }
        public string WHOST_PROFISSAO { get; set; }
        public string SEXO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string AGECTADEB { get; set; }
        public string OPRCTADEB { get; set; }
        public string NUMCTADEB { get; set; }
        public string DIGCTADEB { get; set; }
        public string BILHECOB_COD_OPCAO_PLANO { get; set; }
        public string DTQITBCO { get; set; }
        public string VAL_PAGO { get; set; }
        public string WHOST_RAMO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_SIT_REGISTRO { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_IND { get; set; }
        public string BILHETE_BI_FAIXA_RENDA_FAM { get; set; }
        public string BILHECOB_COD_PRODUTO { get; set; }

        public static void Execute(R3000_10_CONTINUA_DB_INSERT_1_Insert1 r3000_10_CONTINUA_DB_INSERT_1_Insert1)
        {
            var ths = r3000_10_CONTINUA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_10_CONTINUA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}