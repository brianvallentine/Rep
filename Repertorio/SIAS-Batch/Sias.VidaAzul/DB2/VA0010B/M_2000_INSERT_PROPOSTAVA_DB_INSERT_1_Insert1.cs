using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 : QueryBasis<M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0PROPOSTAVA
            (NRCERTIF,
            CODPRODU,
            CODCLIEN,
            OCOREND,
            FONTE,
            AGECOBR,
            OPCAO_COBER,
            DTQITBCO,
            AGECTAVEN,
            OPRCTAVEN,
            NUMCTAVEN,
            DIGCTAVEN,
            NRMATRVEN,
            CODOPER,
            PROFISSAO,
            DTINCLUS,
            DTMOVTO,
            SITUACAO,
            NUM_APOLICE,
            CODSUBES,
            OCORHIST,
            NRPRIPARATZ,
            QTDPARATZ,
            DTPROXVEN,
            NRPARCE,
            DTVENCTO,
            SIT_INTERFACE,
            DTFENAE,
            CODUSU,
            TIMESTAMP,
            IDADE,
            IDE_SEXO,
            ESTADO_CIVIL,
            OPCAO_MARCADA,
            SIGLA_CRM,
            COD_CRM,
            APOS_INVALIDEZ,
            ASSINATURA,
            ACATAMENTO,
            NOME_ESPOSA,
            DTNASC_ESPOSA,
            PROFIS_ESPOSA,
            DPS_TITULAR,
            DPS_ESPOSA,
            NUM_MATRICULA,
            GRAU_PARENTESCO,
            DATA_ADMISSAO,
            NRPROPOS,
            EM_ATIVIDADE,
            LOC_ATIVIDADE,
            INFO_COMPLEMENTAR,
            NRMALADIR,
            NRCERTIFANT,
            COD_CCT)
            VALUES (:V1SEGV-NRCERTIF,
            :V0PROD-CODPRODU,
            :V1SEGV-CODCLI,
            :V1SEGV-OCORR-END,
            :V1SEGV-FONTE,
            :V0PROP-AGECOBR,
            ' ' ,
            :V1SEGV-DTINIVIG,
            0,
            0,
            0,
            0,
            0,
            :V1HSEG-CODOPER,
            ' ' ,
            :V1SEGV-DTINIVIG,
            :V1HSEG-DTMOVTO,
            '3' ,
            :V1SEGV-NUM-APOLICE,
            :V1SEGV-COD-SUBGRUPO,
            :V1SEGV-OCORHIST,
            0,
            0,
            :HOST-DTPROXVEN,
            :V1SEGV-NUM-CARNE,
            :HOST-DTVENCTO,
            ' ' ,
            '9999-12-31' ,
            'VA0010B' ,
            CURRENT TIMESTAMP,
            :HOST-IDADE,
            :V1SEGV-IDE-SEXO,
            :V1SEGV-EST-CIVIL,
            ' ' ,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            :V1SEGV-NRPROPOS,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PROPOSTAVA (NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, AGECTAVEN, OPRCTAVEN, NUMCTAVEN, DIGCTAVEN, NRMATRVEN, CODOPER, PROFISSAO, DTINCLUS, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPRIPARATZ, QTDPARATZ, DTPROXVEN, NRPARCE, DTVENCTO, SIT_INTERFACE, DTFENAE, CODUSU, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, OPCAO_MARCADA, SIGLA_CRM, COD_CRM, APOS_INVALIDEZ, ASSINATURA, ACATAMENTO, NOME_ESPOSA, DTNASC_ESPOSA, PROFIS_ESPOSA, DPS_TITULAR, DPS_ESPOSA, NUM_MATRICULA, GRAU_PARENTESCO, DATA_ADMISSAO, NRPROPOS, EM_ATIVIDADE, LOC_ATIVIDADE, INFO_COMPLEMENTAR, NRMALADIR, NRCERTIFANT, COD_CCT) VALUES ({FieldThreatment(this.V1SEGV_NRCERTIF)}, {FieldThreatment(this.V0PROD_CODPRODU)}, {FieldThreatment(this.V1SEGV_CODCLI)}, {FieldThreatment(this.V1SEGV_OCORR_END)}, {FieldThreatment(this.V1SEGV_FONTE)}, {FieldThreatment(this.V0PROP_AGECOBR)}, ' ' , {FieldThreatment(this.V1SEGV_DTINIVIG)}, 0, 0, 0, 0, 0, {FieldThreatment(this.V1HSEG_CODOPER)}, ' ' , {FieldThreatment(this.V1SEGV_DTINIVIG)}, {FieldThreatment(this.V1HSEG_DTMOVTO)}, '3' , {FieldThreatment(this.V1SEGV_NUM_APOLICE)}, {FieldThreatment(this.V1SEGV_COD_SUBGRUPO)}, {FieldThreatment(this.V1SEGV_OCORHIST)}, 0, 0, {FieldThreatment(this.HOST_DTPROXVEN)}, {FieldThreatment(this.V1SEGV_NUM_CARNE)}, {FieldThreatment(this.HOST_DTVENCTO)}, ' ' , '9999-12-31' , 'VA0010B' , CURRENT TIMESTAMP, {FieldThreatment(this.HOST_IDADE)}, {FieldThreatment(this.V1SEGV_IDE_SEXO)}, {FieldThreatment(this.V1SEGV_EST_CIVIL)}, ' ' , NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, {FieldThreatment(this.V1SEGV_NRPROPOS)}, NULL, NULL, NULL, NULL, NULL, NULL)";

            return query;
        }
        public string V1SEGV_NRCERTIF { get; set; }
        public string V0PROD_CODPRODU { get; set; }
        public string V1SEGV_CODCLI { get; set; }
        public string V1SEGV_OCORR_END { get; set; }
        public string V1SEGV_FONTE { get; set; }
        public string V0PROP_AGECOBR { get; set; }
        public string V1SEGV_DTINIVIG { get; set; }
        public string V1HSEG_CODOPER { get; set; }
        public string V1HSEG_DTMOVTO { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }
        public string V1SEGV_COD_SUBGRUPO { get; set; }
        public string V1SEGV_OCORHIST { get; set; }
        public string HOST_DTPROXVEN { get; set; }
        public string V1SEGV_NUM_CARNE { get; set; }
        public string HOST_DTVENCTO { get; set; }
        public string HOST_IDADE { get; set; }
        public string V1SEGV_IDE_SEXO { get; set; }
        public string V1SEGV_EST_CIVIL { get; set; }
        public string V1SEGV_NRPROPOS { get; set; }

        public static void Execute(M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 m_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1)
        {
            var ths = m_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}