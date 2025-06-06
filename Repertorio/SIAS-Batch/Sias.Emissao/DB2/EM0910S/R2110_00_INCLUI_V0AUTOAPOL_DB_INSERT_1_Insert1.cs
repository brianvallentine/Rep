using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0910S
{
    public class R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1 : QueryBasis<R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0AUTOAPOL
            (COD_EMPRESA,
            FONTE ,
            NRPROPOS ,
            NRITEM ,
            DTINIVIG ,
            DTTERVIG ,
            TIPOVEIC ,
            FABRICAN ,
            CDVEICL ,
            COMBUST ,
            ANOVEICL ,
            ANOMOD ,
            CORVEICL ,
            CAPACID ,
            LOTACAO ,
            PLACAUF ,
            PLACALET ,
            PLACANR ,
            CHASSIS ,
            UTILIZA ,
            QTACESS ,
            DTBAIXA ,
            CDVISTOR ,
            PROPRIET ,
            DTIVEXTP ,
            ACEITE ,
            NRPRRESS ,
            PROTSINI ,
            SITUACAO ,
            CODCLIEN ,
            NUM_APOLICE,
            NRENDOS ,
            TIMESTAMP ,
            TPMOVTO ,
            ZEROKM ,
            SEGBONUS ,
            FIDEL_AUTO ,
            FIDEL_VIDA ,
            FIDEL_PREV ,
            DANOS_MORAIS ,
            SEG_MERC_DET ,
            ADIC_VLR_MERCADO ,
            PERFIL ,
            DESPEXTR ,
            VLNOVO,
            CODDESPEXTR,
            DESPEXTR_PT,
            PERC_VARIACAO_IS,
            CANAL_PROPOSTA,
            TIPO_COBRANCA,
            NUM_PROPOSTA_CONV,
            NUM_CERTIFICADO,
            NUM_RENAVAM,
            COD_CI ,
            NUM_CONTRATO_CONV,
            NUM_RECIBO_CONV,
            COD_IDENT_PEP,
            IND_REL_CLI_PROPR ,
            IND_USO_VEICULO ,
            IND_ORIGEM_PROP ,
            COD_CONGENERE ,
            COD_CBO_CONV,
            COD_ATIVIDADE_CONV)
            VALUES (:V0AUTO-COD-EMPRESA,
            :V0AUTO-FONTE ,
            :V0AUTO-NRPROPOS ,
            :V0AUTO-NRITEM ,
            :V0AUTO-DTINIVIG ,
            :V0AUTO-DTTERVIG ,
            :V0AUTO-TIPOVEIC ,
            :V0AUTO-FABRICAN ,
            :V0AUTO-CDVEICL ,
            :V0AUTO-COMBUST ,
            :V0AUTO-ANOVEICL ,
            :V0AUTO-ANOMOD ,
            :V0AUTO-CORVEICL ,
            :V0AUTO-CAPACID ,
            :V0AUTO-LOTACAO ,
            :V0AUTO-PLACAUF ,
            :V0AUTO-PLACALET ,
            :V0AUTO-PLACANR ,
            :V0AUTO-CHASSIS ,
            :V0AUTO-UTILIZA ,
            :V0AUTO-QTACESS ,
            :V0AUTO-DTBAIXA ,
            :V0AUTO-CDVISTOR ,
            :V0AUTO-PROPRIET ,
            :V0AUTO-DTIVEXTP ,
            :V0AUTO-ACEITE ,
            :V0AUTO-NRPRRESS ,
            :V0AUTO-PROTSINI ,
            :V0AUTO-SITUACAO ,
            :V0AUTO-CODCLIEN ,
            :V0AUTO-NUM-APOL ,
            :V0AUTO-NRENDOS ,
            CURRENT TIMESTAMP ,
            :V0AUTO-TPMOVTO ,
            :V0AUTO-ZEROKM:V1INDI-ZEROKM ,
            :V0AUTO-SEGBONUS:V1INDI-SEGBONUS,
            :V0AUTO-FIDEL-AUTO ,
            :V0AUTO-FIDEL-VIDA ,
            :V0AUTO-FIDEL-PREV ,
            :V0AUTO-DANOS-MORAIS ,
            :V0AUTO-SEG-MERC-DET ,
            :V0AUTO-ADIC-VLR-MERCADO ,
            :V0AUTO-PERFIL ,
            :V0AUTO-DESPEXTR ,
            :V0AUTO-VLNOVO,
            :V0AUTO-CODDESPEXTR,
            :V0AUTO-DESPEXTR-PT,
            :V0AUTO-VARIA-IS,
            :V0AUTO-CANAL-PROPOSTA ,
            :V0AUTO-TIPO-COBRANCA,
            :V0AUTO-NUM-PROP-CONV,
            :V0AUTO-NUM-CERTIF,
            :V0AUTO-NUM-RENAVAM,
            NULL,
            NULL,
            NULL,
            NULL,
            0,
            :V0AUTO-IND-USO-VEIC,
            99,
            :WHOST-CONGENERE,
            999,
            99)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0AUTOAPOL (COD_EMPRESA, FONTE , NRPROPOS , NRITEM , DTINIVIG , DTTERVIG , TIPOVEIC , FABRICAN , CDVEICL , COMBUST , ANOVEICL , ANOMOD , CORVEICL , CAPACID , LOTACAO , PLACAUF , PLACALET , PLACANR , CHASSIS , UTILIZA , QTACESS , DTBAIXA , CDVISTOR , PROPRIET , DTIVEXTP , ACEITE , NRPRRESS , PROTSINI , SITUACAO , CODCLIEN , NUM_APOLICE, NRENDOS , TIMESTAMP , TPMOVTO , ZEROKM , SEGBONUS , FIDEL_AUTO , FIDEL_VIDA , FIDEL_PREV , DANOS_MORAIS , SEG_MERC_DET , ADIC_VLR_MERCADO , PERFIL , DESPEXTR , VLNOVO, CODDESPEXTR, DESPEXTR_PT, PERC_VARIACAO_IS, CANAL_PROPOSTA, TIPO_COBRANCA, NUM_PROPOSTA_CONV, NUM_CERTIFICADO, NUM_RENAVAM, COD_CI , NUM_CONTRATO_CONV, NUM_RECIBO_CONV, COD_IDENT_PEP, IND_REL_CLI_PROPR , IND_USO_VEICULO , IND_ORIGEM_PROP , COD_CONGENERE , COD_CBO_CONV, COD_ATIVIDADE_CONV) VALUES ({FieldThreatment(this.V0AUTO_COD_EMPRESA)}, {FieldThreatment(this.V0AUTO_FONTE)} , {FieldThreatment(this.V0AUTO_NRPROPOS)} , {FieldThreatment(this.V0AUTO_NRITEM)} , {FieldThreatment(this.V0AUTO_DTINIVIG)} , {FieldThreatment(this.V0AUTO_DTTERVIG)} , {FieldThreatment(this.V0AUTO_TIPOVEIC)} , {FieldThreatment(this.V0AUTO_FABRICAN)} , {FieldThreatment(this.V0AUTO_CDVEICL)} , {FieldThreatment(this.V0AUTO_COMBUST)} , {FieldThreatment(this.V0AUTO_ANOVEICL)} , {FieldThreatment(this.V0AUTO_ANOMOD)} , {FieldThreatment(this.V0AUTO_CORVEICL)} , {FieldThreatment(this.V0AUTO_CAPACID)} , {FieldThreatment(this.V0AUTO_LOTACAO)} , {FieldThreatment(this.V0AUTO_PLACAUF)} , {FieldThreatment(this.V0AUTO_PLACALET)} , {FieldThreatment(this.V0AUTO_PLACANR)} , {FieldThreatment(this.V0AUTO_CHASSIS)} , {FieldThreatment(this.V0AUTO_UTILIZA)} , {FieldThreatment(this.V0AUTO_QTACESS)} , {FieldThreatment(this.V0AUTO_DTBAIXA)} , {FieldThreatment(this.V0AUTO_CDVISTOR)} , {FieldThreatment(this.V0AUTO_PROPRIET)} , {FieldThreatment(this.V0AUTO_DTIVEXTP)} , {FieldThreatment(this.V0AUTO_ACEITE)} , {FieldThreatment(this.V0AUTO_NRPRRESS)} , {FieldThreatment(this.V0AUTO_PROTSINI)} , {FieldThreatment(this.V0AUTO_SITUACAO)} , {FieldThreatment(this.V0AUTO_CODCLIEN)} , {FieldThreatment(this.V0AUTO_NUM_APOL)} , {FieldThreatment(this.V0AUTO_NRENDOS)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0AUTO_TPMOVTO)} ,  {FieldThreatment((this.V1INDI_ZEROKM?.ToInt() == -1 ? null : this.V0AUTO_ZEROKM))} ,  {FieldThreatment((this.V1INDI_SEGBONUS?.ToInt() == -1 ? null : this.V0AUTO_SEGBONUS))}, {FieldThreatment(this.V0AUTO_FIDEL_AUTO)} , {FieldThreatment(this.V0AUTO_FIDEL_VIDA)} , {FieldThreatment(this.V0AUTO_FIDEL_PREV)} , {FieldThreatment(this.V0AUTO_DANOS_MORAIS)} , {FieldThreatment(this.V0AUTO_SEG_MERC_DET)} , {FieldThreatment(this.V0AUTO_ADIC_VLR_MERCADO)} , {FieldThreatment(this.V0AUTO_PERFIL)} , {FieldThreatment(this.V0AUTO_DESPEXTR)} , {FieldThreatment(this.V0AUTO_VLNOVO)}, {FieldThreatment(this.V0AUTO_CODDESPEXTR)}, {FieldThreatment(this.V0AUTO_DESPEXTR_PT)}, {FieldThreatment(this.V0AUTO_VARIA_IS)}, {FieldThreatment(this.V0AUTO_CANAL_PROPOSTA)} , {FieldThreatment(this.V0AUTO_TIPO_COBRANCA)}, {FieldThreatment(this.V0AUTO_NUM_PROP_CONV)}, {FieldThreatment(this.V0AUTO_NUM_CERTIF)}, {FieldThreatment(this.V0AUTO_NUM_RENAVAM)}, NULL, NULL, NULL, NULL, 0, {FieldThreatment(this.V0AUTO_IND_USO_VEIC)}, 99, {FieldThreatment(this.WHOST_CONGENERE)}, 999, 99)";

            return query;
        }
        public string V0AUTO_COD_EMPRESA { get; set; }
        public string V0AUTO_FONTE { get; set; }
        public string V0AUTO_NRPROPOS { get; set; }
        public string V0AUTO_NRITEM { get; set; }
        public string V0AUTO_DTINIVIG { get; set; }
        public string V0AUTO_DTTERVIG { get; set; }
        public string V0AUTO_TIPOVEIC { get; set; }
        public string V0AUTO_FABRICAN { get; set; }
        public string V0AUTO_CDVEICL { get; set; }
        public string V0AUTO_COMBUST { get; set; }
        public string V0AUTO_ANOVEICL { get; set; }
        public string V0AUTO_ANOMOD { get; set; }
        public string V0AUTO_CORVEICL { get; set; }
        public string V0AUTO_CAPACID { get; set; }
        public string V0AUTO_LOTACAO { get; set; }
        public string V0AUTO_PLACAUF { get; set; }
        public string V0AUTO_PLACALET { get; set; }
        public string V0AUTO_PLACANR { get; set; }
        public string V0AUTO_CHASSIS { get; set; }
        public string V0AUTO_UTILIZA { get; set; }
        public string V0AUTO_QTACESS { get; set; }
        public string V0AUTO_DTBAIXA { get; set; }
        public string V0AUTO_CDVISTOR { get; set; }
        public string V0AUTO_PROPRIET { get; set; }
        public string V0AUTO_DTIVEXTP { get; set; }
        public string V0AUTO_ACEITE { get; set; }
        public string V0AUTO_NRPRRESS { get; set; }
        public string V0AUTO_PROTSINI { get; set; }
        public string V0AUTO_SITUACAO { get; set; }
        public string V0AUTO_CODCLIEN { get; set; }
        public string V0AUTO_NUM_APOL { get; set; }
        public string V0AUTO_NRENDOS { get; set; }
        public string V0AUTO_TPMOVTO { get; set; }
        public string V0AUTO_ZEROKM { get; set; }
        public string V1INDI_ZEROKM { get; set; }
        public string V0AUTO_SEGBONUS { get; set; }
        public string V1INDI_SEGBONUS { get; set; }
        public string V0AUTO_FIDEL_AUTO { get; set; }
        public string V0AUTO_FIDEL_VIDA { get; set; }
        public string V0AUTO_FIDEL_PREV { get; set; }
        public string V0AUTO_DANOS_MORAIS { get; set; }
        public string V0AUTO_SEG_MERC_DET { get; set; }
        public string V0AUTO_ADIC_VLR_MERCADO { get; set; }
        public string V0AUTO_PERFIL { get; set; }
        public string V0AUTO_DESPEXTR { get; set; }
        public string V0AUTO_VLNOVO { get; set; }
        public string V0AUTO_CODDESPEXTR { get; set; }
        public string V0AUTO_DESPEXTR_PT { get; set; }
        public string V0AUTO_VARIA_IS { get; set; }
        public string V0AUTO_CANAL_PROPOSTA { get; set; }
        public string V0AUTO_TIPO_COBRANCA { get; set; }
        public string V0AUTO_NUM_PROP_CONV { get; set; }
        public string V0AUTO_NUM_CERTIF { get; set; }
        public string V0AUTO_NUM_RENAVAM { get; set; }
        public string V0AUTO_IND_USO_VEIC { get; set; }
        public string WHOST_CONGENERE { get; set; }

        public static void Execute(R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1 r2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1)
        {
            var ths = r2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}