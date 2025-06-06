using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1184B
{
    public class M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1 : QueryBasis<M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0COBERPROPVA
            ( NRCERTIF
            ,OCORHIST
            ,DTINIVIG
            ,DTTERVIG
            ,IMPSEGUR
            ,QUANT_VIDAS
            ,IMPSEGIND
            ,CODOPER
            ,OPCAO_COBER
            ,IMPMORNATU
            ,IMPMORACID
            ,IMPINVPERM
            ,IMPAMDS
            ,IMPDH
            ,IMPDIT
            ,VLPREMIO
            ,PRMVG
            ,PRMAP
            ,QTTITCAP
            ,VLTITCAP
            ,VLCUSTCAP
            ,IMPSEGCDC
            ,VLCUSTCDG
            ,CODUSU
            ,TIMESTAMP
            ,IMPSEGAUXF
            ,VLCUSTAUXF
            ,PRMDIT
            ,QTDIT )
            VALUES (:RELATO-NRCERTIF,
            :PROPVA-OCORHIST,
            :RELATO-DTSOLICITACAO,
            '9999-12-31' ,
            :COBERP-IMPMORNATU-ATU,
            1,
            :COBERP-IMPMORNATU-ATU,
            :RELATO-OPERACAO,
            :PROPVA-OPCAO-COBER,
            :COBERP-IMPMORNATU-ATU,
            :COBERP-IMPMORACID-ATU,
            :COBERP-IMPINVPERM-ATU,
            :COBERP-IMPAMDS-ATU,
            :COBERP-IMPDH-ATU,
            :COBERP-IMPDIT-ATU,
            :COBERP-VLPREMIO-ATU,
            :COBERP-PRMVG-ATU,
            :COBERP-PRMAP-ATU,
            :COBERP-QTTITCAP,
            :COBERP-VLTITCAP,
            :COBERP-VLCUSTCAP,
            :COBERP-IMPSEGCDG,
            :COBERP-VLCUSTCDG,
            'VA1184B' ,
            CURRENT TIMESTAMP,
            :COBERP-IMPSEGAUXF:COBERP-IMPSEGAUXF-I,
            :COBERP-VLCUSTAUXF:COBERP-VLCUSTAUXF-I,
            :COBERP-PRMDIT-ANT:COBERP-PRMDIT-I,
            :COBERP-QTDIT:COBERP-QTDIT-I)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0COBERPROPVA ( NRCERTIF ,OCORHIST ,DTINIVIG ,DTTERVIG ,IMPSEGUR ,QUANT_VIDAS ,IMPSEGIND ,CODOPER ,OPCAO_COBER ,IMPMORNATU ,IMPMORACID ,IMPINVPERM ,IMPAMDS ,IMPDH ,IMPDIT ,VLPREMIO ,PRMVG ,PRMAP ,QTTITCAP ,VLTITCAP ,VLCUSTCAP ,IMPSEGCDC ,VLCUSTCDG ,CODUSU ,TIMESTAMP ,IMPSEGAUXF ,VLCUSTAUXF ,PRMDIT ,QTDIT ) VALUES ({FieldThreatment(this.RELATO_NRCERTIF)}, {FieldThreatment(this.PROPVA_OCORHIST)}, {FieldThreatment(this.RELATO_DTSOLICITACAO)}, '9999-12-31' , {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, 1, {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, {FieldThreatment(this.RELATO_OPERACAO)}, {FieldThreatment(this.PROPVA_OPCAO_COBER)}, {FieldThreatment(this.COBERP_IMPMORNATU_ATU)}, {FieldThreatment(this.COBERP_IMPMORACID_ATU)}, {FieldThreatment(this.COBERP_IMPINVPERM_ATU)}, {FieldThreatment(this.COBERP_IMPAMDS_ATU)}, {FieldThreatment(this.COBERP_IMPDH_ATU)}, {FieldThreatment(this.COBERP_IMPDIT_ATU)}, {FieldThreatment(this.COBERP_VLPREMIO_ATU)}, {FieldThreatment(this.COBERP_PRMVG_ATU)}, {FieldThreatment(this.COBERP_PRMAP_ATU)}, {FieldThreatment(this.COBERP_QTTITCAP)}, {FieldThreatment(this.COBERP_VLTITCAP)}, {FieldThreatment(this.COBERP_VLCUSTCAP)}, {FieldThreatment(this.COBERP_IMPSEGCDG)}, {FieldThreatment(this.COBERP_VLCUSTCDG)}, 'VA1184B' , CURRENT TIMESTAMP,  {FieldThreatment((this.COBERP_IMPSEGAUXF_I?.ToInt() == -1 ? null : this.COBERP_IMPSEGAUXF))},  {FieldThreatment((this.COBERP_VLCUSTAUXF_I?.ToInt() == -1 ? null : this.COBERP_VLCUSTAUXF))},  {FieldThreatment((this.COBERP_PRMDIT_I?.ToInt() == -1 ? null : this.COBERP_PRMDIT_ANT))},  {FieldThreatment((this.COBERP_QTDIT_I?.ToInt() == -1 ? null : this.COBERP_QTDIT))})";

            return query;
        }
        public string RELATO_NRCERTIF { get; set; }
        public string PROPVA_OCORHIST { get; set; }
        public string RELATO_DTSOLICITACAO { get; set; }
        public string COBERP_IMPMORNATU_ATU { get; set; }
        public string RELATO_OPERACAO { get; set; }
        public string PROPVA_OPCAO_COBER { get; set; }
        public string COBERP_IMPMORACID_ATU { get; set; }
        public string COBERP_IMPINVPERM_ATU { get; set; }
        public string COBERP_IMPAMDS_ATU { get; set; }
        public string COBERP_IMPDH_ATU { get; set; }
        public string COBERP_IMPDIT_ATU { get; set; }
        public string COBERP_VLPREMIO_ATU { get; set; }
        public string COBERP_PRMVG_ATU { get; set; }
        public string COBERP_PRMAP_ATU { get; set; }
        public string COBERP_QTTITCAP { get; set; }
        public string COBERP_VLTITCAP { get; set; }
        public string COBERP_VLCUSTCAP { get; set; }
        public string COBERP_IMPSEGCDG { get; set; }
        public string COBERP_VLCUSTCDG { get; set; }
        public string COBERP_IMPSEGAUXF { get; set; }
        public string COBERP_IMPSEGAUXF_I { get; set; }
        public string COBERP_VLCUSTAUXF { get; set; }
        public string COBERP_VLCUSTAUXF_I { get; set; }
        public string COBERP_PRMDIT_ANT { get; set; }
        public string COBERP_PRMDIT_I { get; set; }
        public string COBERP_QTDIT { get; set; }
        public string COBERP_QTDIT_I { get; set; }

        public static void Execute(M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1 m_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1)
        {
            var ths = m_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0300_ATUALIZA_TABELAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}